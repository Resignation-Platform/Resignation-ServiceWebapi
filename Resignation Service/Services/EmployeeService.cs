using AutoMapper;
using Resignation_Service.Models;
using Resignation_Service.Repository;
using Resignation_Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Resignation_Service.Services
{
   
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }

       
        public  EmployeeViewModel FetchEmployeeDetail(string empName)
        {
            Employee employeeDetails =  this.employeeRepository.FetchEmployeeDetail(empName);
            string emp_Name=employeeDetails.txtEmpMailId.Split('@')[0];
            var employee_mapper= this.mapper.Map<EmployeeViewModel>(employeeDetails);

            employee_mapper.EmployeeName = emp_Name;
            return employee_mapper;
        }

       
        public EmployeeExitViewModel FetchEmployeeExitDetails(string empNo)
        {
            EmployeeExit employeeExitDetails = this.employeeRepository.FetchEmployeeExitDetails(empNo);
            return this.mapper.Map<EmployeeExitViewModel>(employeeExitDetails);
        }

        
        public List<FeedbackViewModel> FetchFeedbackQuestions()
        {
            List<Feedback> feedBack = this.employeeRepository.FetchFeedbackQuestions();
            return this.mapper.Map<List<FeedbackViewModel>>(feedBack);
        }

        
        public string SaveEmployeeExitDetails(EmployeeExitDetailsViewModel employeeExitData)
        {
            EmployeeExitDetails employeeExit = this.mapper.Map<EmployeeExitDetails>(employeeExitData);
            employeeExit.dtSeparationDate = DateTime.Today;
            employeeExit.dtLastWorkingDate = DateTime.Today.AddDays(60);
            var feedback_mapp = this.mapper.Map<List<ExitFeedback>>(employeeExitData.Feedbacks);
            return this.employeeRepository.SaveEmployeeExitDetails(employeeExit, feedback_mapp);
        }
        public string UpdateAdminApprovals(string exitEmpNo, string adminRole)
        {
            string status=this.employeeRepository.UpdateAdminApprovals(exitEmpNo, adminRole);

            return status;
        }
    }
}
