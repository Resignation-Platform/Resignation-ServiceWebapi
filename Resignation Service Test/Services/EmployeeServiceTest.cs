using AutoMapper;
using Moq;
using Resignation_Service.Models;
using Resignation_Service.Repository;
using Resignation_Service.Services;
using Resignation_Service.Utility.AutoMapper;
using Resignation_Service.ViewModels;
using Resignation_Service_Test.Helper;
using System;
using System.Collections.Generic;
using Xunit;

namespace Resignation_Service_Test.Services
{
    /// <summary>
    /// Employee service test
    /// </summary>
    public class EmployeeServiceTest
    {
        private readonly Mock<IEmployeeRepository> employeeRepository;
        private readonly Mock<IAdminRepository> adminRepository;

        private readonly IMapper mapper;

        private EmployeeService employeeService;
        private AdminService adminService;

        public EmployeeServiceTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            this.employeeRepository = new Mock<IEmployeeRepository>();
            this.adminRepository = new Mock<IAdminRepository>();
            this.mapper = mapper;
            this.employeeService = new EmployeeService(this.mapper, this.employeeRepository.Object);
            this.adminService=new AdminService(this.adminRepository.Object,this.mapper);
        }

        [Fact]
        public  void FetchEmployeeDetails_HasEmployeeDetails_ReturnsEmployeeDetails()
        {
            // Arrange
            string empName = "test1";
            Employee employeeData = MockData.FetchEmployeeData();
            this.employeeRepository.Setup((x) => x.FetchEmployeeDetail(It.IsAny<string>()))
                .Returns(employeeData);

            // Act
            EmployeeViewModel result = this.employeeService.FetchEmployeeDetail(empName);

            // Assert
            Assert.Equal(employeeData.txtEmpMailId, result.Email);
            Assert.Equal(employeeData.txtHR, result.HRName);
            Assert.Equal(employeeData.txtEmpRole, result.Role);
        }

        [Fact]
        public void FetchFeedbackQuestions_HasFeedbackQuestions_ReturnsFeedbackQuestions()
        {
            // Arrange
            List<Feedback> feedbackQuestions = MockData.FetchFeedbackData();
            this.employeeRepository.Setup((x) => x.FetchFeedbackQuestions()).Returns(feedbackQuestions);

            // Act
            List<FeedbackViewModel> result = this.employeeService.FetchFeedbackQuestions();

            // Assert
            Assert.Equal(feedbackQuestions[0].intId, result[0].FeedbackId);
            Assert.Equal(feedbackQuestions[0].txtQuestion, result[0].FeedbackQuestion);
            Assert.Equal(feedbackQuestions[0].txtOptions, result[0].Options);
        }

        [Fact]
        public void UpdateAdminApprovals_HasAdminApproveRequest_ReturnsUpdateStatus()
        {
            string LoggedUserRole = "HR";
            string ExitEmployee = "1024";
            //Arrange
            string adminUpdateStatus = MockData.UpdateAdminActions();
            this.employeeRepository.Setup((x)=>x.UpdateAdminApprovals(It.IsAny<string>(),It.IsAny<string>())).Returns(adminUpdateStatus);

            //Act
            string result = this.employeeService.UpdateAdminApprovals(ExitEmployee, LoggedUserRole);

            Assert.Equal(adminUpdateStatus, result);
        }
        [Fact]
        public void FetchAdminDetails_HasAdminApprovalList_ReturnsEmployeeList()
        {
            string AdminEmpno = "1025";
            string Adminrole = "HR";
            //Arrange
            List<AdminDetails> adminDetails = MockData.FetchAdminData();
            this.adminRepository.Setup(x=>x.FetchDetailsForAdmin(It.IsAny<string>(),It.IsAny<string>())).Returns(adminDetails);

            //Act
            List<AdminDetailsViewModel> result=this.adminService.FetchDetailsForAdmin(AdminEmpno, Adminrole);

            //Assert
            Assert.Equal(adminDetails[0].txtEmployeeNo, result[0].EmployeeNo);
            Assert.Equal(adminDetails[0].txtEmpEmailId, result[0].EmployeeEmailId);
            Assert.Equal(adminDetails[0].dtSeperationDate,result[0].SeperationDate);
        }
        [Fact]
        public void SaveEmployeeExitDetails_SavedEmployeeDetails_ReturnsSavedStatus()
        {
            // Arrange
            string savedStatus = "Data saved";
            EmployeeExitViewModel employeeExitData = MockData.GetEmployeeExitData();
            this.employeeRepository.Setup(x => x.SaveEmployeeExitDetails(It.IsAny<EmployeeExit>(), It.IsAny<List<ExitFeedback>>()))
                .Returns(savedStatus);

            // Act
            string result = this.employeeService.SaveEmployeeExitDetails(employeeExitData);

            // Assert
            Assert.Equal(savedStatus, result);
            this.employeeRepository.Verify(
                x => x.SaveEmployeeExitDetails(
                    It.Is<EmployeeExit>(
                        x => x.dtLastWorkingDate == DateTime.Today.AddDays(60)
                        && x.txtEmployeeNumber == employeeExitData.EmployeeNumber), employeeExitData.Feedbacks), Times.Once);
        }
    }
}
