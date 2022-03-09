using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Resignation_Service.Services;
using Resignation_Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resignation_Service.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        [HttpGet]
        [Route("{empName}")]
        public IActionResult FetchEmployeeDetails(string empName)
        {
            if (!string.IsNullOrWhiteSpace(empName))
            {
                EmployeeViewModel employeeView =  this.employeeService.FetchEmployeeDetail(empName);
                return employeeView != null ? this.Ok(employeeView) : this.NotFound();
            }

            string errorMessage = "Please check the input parameter";
            return this.BadRequest(errorMessage);
        }

        
        [HttpGet]
        [Route("[action]/{empNo}")]
        //sudhanshu
        public IActionResult FetchEmployeeExitDetails(string empNo)
        {
            if (!string.IsNullOrWhiteSpace(empNo))
            {
                EmployeeExitViewModel employeeView = this.employeeService.FetchEmployeeExitDetails(empNo);
                return employeeView != null ? this.Ok(employeeView) : this.NotFound();
            }

            string errorMessage = "Please check the input parameter";
            return this.BadRequest(errorMessage);
        }

        
        [HttpGet]
        [Route("Feedback")]
        public IActionResult FetchFeedBackQuestions()
        {
            List<FeedbackViewModel> feedbackView = this.employeeService.FetchFeedbackQuestions();
            return feedbackView != null ? this.Ok(feedbackView) : this.NotFound();
        }


        [HttpPost]
        public IActionResult SaveEmployeeExitDetails([FromBody] EmployeeExitDetailsViewModel employeeExitData)
        {
            string saveEmployeeExitStatus = this.employeeService.SaveEmployeeExitDetails(employeeExitData);
            return !string.IsNullOrWhiteSpace(saveEmployeeExitStatus) ? this.Ok(saveEmployeeExitStatus) : this.BadRequest();
        }


        [HttpPut]
        [Route("AdminApprovals")]
        public IActionResult UpdateAdminApprovals([FromBody] AdminAcceptance exitEmpObj)
        {
            string updateStatus = string.Empty;
            string exitEmpNo = exitEmpObj.ExitEmpNo;
            string adminRole = exitEmpObj.AdminRole;
            if (!string.IsNullOrWhiteSpace(exitEmpNo)&& !string.IsNullOrWhiteSpace(adminRole))
            {

                 updateStatus= this.employeeService.UpdateAdminApprovals(exitEmpNo, adminRole);
                return updateStatus!=null ? this.Ok(updateStatus) : this.NotFound();
            }
            return this.BadRequest("Check the object passed ");
        }
    }
}
