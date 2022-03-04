using Microsoft.AspNetCore.Mvc;
using Moq;
using Resignation_Service.Controllers;
using Resignation_Service.Services;
using Resignation_Service.ViewModels;
using Resignation_Service_Test.Helper;
using System.Collections.Generic;
using Xunit;

namespace Resignation_Service_Test.Controllers
{
    /// <summary>
    /// Employee controller test
    /// </summary>
    public class EmployeesControllerTest
    {
        private readonly Mock<IEmployeeService> employeeService;
        private readonly Mock<IAdminService> adminService;

        private EmployeesController employeesController;
        private AdminController adminController;

        public EmployeesControllerTest()
        {
            this.employeeService = new Mock<IEmployeeService>();
            this.adminService= new Mock<IAdminService>();
            this.employeesController = new EmployeesController(this.employeeService.Object);
            this.adminController= new AdminController(this.adminService.Object);

        }

        [Fact]
        public  void FetchEmployeeDetails_HasEmployeeDetails_ReturnsOk()
        {
            // Arrange
            string empName = "Test";
            EmployeeViewModel employeeDetails = MockData.FetchEmployeeDetails();
            this.employeeService.Setup((x) => x.FetchEmployeeDetail(It.IsAny<string>())).Returns(employeeDetails);

            // Act
            IActionResult result =  this.employeesController.FetchEmployeeDetails(empName);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal((result as OkObjectResult).Value, employeeDetails);
            this.employeeService.Verify(x => x.FetchEmployeeDetail(empName), Times.Once);
        }

        [Fact]
        public  void FetchEmployeeDetails_HasNoEmployeeDetails_ReturnsNotFound()
        {
            // Arrange
            string empName = "Test2";
            EmployeeViewModel employeeDetails = null;
            this.employeeService.Setup((x) => x.FetchEmployeeDetail(It.IsAny<string>())).Returns(employeeDetails);

            // Act
            IActionResult result = this.employeesController.FetchEmployeeDetails(empName);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            this.employeeService.Verify(x => x.FetchEmployeeDetail(empName), Times.Once);
        }

        [Fact]
        public  void FetchEmployeeDetails_InvalidInput_ReturnsBadRequest()
        {
            // Arrange
            string empName = null;

            // Act
            IActionResult result =  this.employeesController.FetchEmployeeDetails(empName);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            this.employeeService.Verify(x => x.FetchEmployeeDetail(empName), Times.Never);
        }

        [Fact]
        public void FetchFeedBackQuestions_HasFeedbackQuestions_ReturnsOk()
        {
            // Arrange
            List<FeedbackViewModel> feedbackQuestions = MockData.FetchFeedbackViewData();
            this.employeeService.Setup((x) => x.FetchFeedbackQuestions()).Returns(feedbackQuestions);

            // Act
            IActionResult result = this.employeesController.FetchFeedBackQuestions();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            this.employeeService.Verify(x => x.FetchFeedbackQuestions(), Times.Once);
        }

        [Fact]
        public void FetchFeedBackQuestions_HasNoFeedbackQuestions_ReturnsNotFound()
        {
            // Arrange
            List<FeedbackViewModel> feedbackQuestions = null;
            this.employeeService.Setup((x) => x.FetchFeedbackQuestions()).Returns(feedbackQuestions);

            // Act
            IActionResult result = this.employeesController.FetchFeedBackQuestions();

            // Assert
            Assert.IsType<NotFoundResult>(result);
            this.employeeService.Verify(x => x.FetchFeedbackQuestions(), Times.Once);
        }

        [Fact]
        public void UpdateAdminAcceptance_HasUpdateStatus_ReturnsOk()
        {
            //Arrange
            AdminAcceptance adminobj = new AdminAcceptance() 
            { ExitEmpNo="1024",AdminRole="HR"};

            string UpdateStatus = MockData.UpdateAdminActions();
            this.employeeService.Setup(x=>x.UpdateAdminApprovals(adminobj.ExitEmpNo,adminobj.AdminRole)).Returns(UpdateStatus);
            //Act
            IActionResult result=this.employeesController.UpdateAdminApprovals(adminobj);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal((result as OkObjectResult).Value, UpdateStatus);
            this.employeeService.Verify(x => x.UpdateAdminApprovals(adminobj.ExitEmpNo,adminobj.AdminRole), Times.Once);

        }
        [Fact]
        public void UpdateAdminAcceptance_HasUpdateStatus_ReturnsNotFound()
        {
            //Arrange
            AdminAcceptance adminobj = new AdminAcceptance()
            { ExitEmpNo = "1024", AdminRole = "HR" };

            string UpdateStatus = null;
            this.employeeService.Setup(x => x.UpdateAdminApprovals(adminobj.ExitEmpNo, adminobj.AdminRole)).Returns(UpdateStatus);
            //Act
            IActionResult result = this.employeesController.UpdateAdminApprovals(adminobj);

            //Assert
            Assert.IsType<NotFoundResult>(result);
           
            this.employeeService.Verify(x => x.UpdateAdminApprovals(adminobj.ExitEmpNo, adminobj.AdminRole), Times.Once);

        }
        [Fact]
        public void UpdateAdminAcceptance_HasUpdateStatus_ReturnsBadRequest()
        {
            //Arrange
            AdminAcceptance adminobj = new AdminAcceptance() { };
            
             //Act
            IActionResult result = this.employeesController.UpdateAdminApprovals(adminobj);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
            
            this.employeeService.Verify(x => x.UpdateAdminApprovals(adminobj.ExitEmpNo, adminobj.AdminRole), Times.Never);

        }
        [Fact]
        public void FetchAdminDetails_HasEmployeeExitDetails_ReturnsOkRequest()
        {
            string AdminEmpno = "1025";
            string Adminrole = "HR";
            //Arrange
            List<AdminDetailsViewModel> adminDetails = MockData.FetchAdminViewData();
            this.adminService.Setup(x => x.FetchDetailsForAdmin(It.IsAny<string>(), It.IsAny<string>())).Returns(adminDetails);

            //Act
            IActionResult result = this.adminController.FetchAdminActionItems(AdminEmpno, Adminrole);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(adminDetails, (result as OkObjectResult).Value);
            this.adminService.Verify(x=>x.FetchDetailsForAdmin(AdminEmpno,Adminrole), Times.Once);  
            
        }
        [Fact]
        public void FetchAdminDetails_HasEmployeeExitDetails_ReturnsNotFoundRequest()
        {
            string AdminEmpno = "1025";
            string Adminrole = "HR";
            //Arrange
            List<AdminDetailsViewModel> adminDetails = null;
            this.adminService.Setup(x => x.FetchDetailsForAdmin(It.IsAny<string>(), It.IsAny<string>())).Returns(adminDetails);

            //Act
            IActionResult result = this.adminController.FetchAdminActionItems(AdminEmpno, Adminrole);

            //Assert
            Assert.IsType<NotFoundResult>(result);
            this.adminService.Verify(x => x.FetchDetailsForAdmin(AdminEmpno, Adminrole), Times.Once);

        }
        [Fact]
        public void FetchAdminDetails_HasEmployeeExitDetails_ReturnsBadRequest()
        {
            //Arrange
            string AdminEmpno =null;
            string Adminrole = "HR";
            
            //Act
            IActionResult result = this.adminController.FetchAdminActionItems(AdminEmpno, Adminrole);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
            this.adminService.Verify(x => x.FetchDetailsForAdmin(AdminEmpno, Adminrole), Times.Never);

        }
        [Fact]
        public void SaveEmployeeExitDetails_SavedEmployeeDetails_ReturnsOk()
        {
            //Arrange
            string savedStatus = "Data saved";
            EmployeeExitViewModel employeeExitData = MockData.GetEmployeeExitData();
            this.employeeService.Setup(x => x.SaveEmployeeExitDetails(It.IsAny<EmployeeExitViewModel>()))
                .Returns(savedStatus);

            //Act
            IActionResult result = this.employeesController.SaveEmployeeExitDetails(employeeExitData);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(savedStatus, (result as OkObjectResult).Value);
            this.employeeService.Verify(x => x.SaveEmployeeExitDetails(employeeExitData), Times.Once);
        }
        [Fact]
        public void SaveEmployeeExitDetails_SaveUnsuccessful_ReturnsNotFound()
        {
            //Arrange
            EmployeeExitViewModel employeeExitData = MockData.GetEmployeeExitData();
            this.employeeService.Setup(x => x.SaveEmployeeExitDetails(It.IsAny<EmployeeExitViewModel>()))
                .Returns(string.Empty);

            //Act
            IActionResult result = this.employeesController.SaveEmployeeExitDetails(employeeExitData);

            //Assert
            Assert.IsType<BadRequestResult>(result);
            this.employeeService.Verify(x => x.SaveEmployeeExitDetails(employeeExitData), Times.Once);
        }
    }
}
