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
    /// <summary>
    /// Employee service class
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Fetches the employee details
        /// </summary>
        /// <param name="empName">Employee name</param>
        /// <returns>Employee details</returns>
        public  EmployeeViewModel FetchEmployeeDetail(string empName)
        {
            Employee employeeDetails =  this.employeeRepository.FetchEmployeeDetail(empName);
            return this.mapper.Map<EmployeeViewModel>(employeeDetails);
        }

        /// <summary>
        /// Fetches the employee exit details
        /// </summary>
        /// <param name="empNo">Employee Number</param>
        /// <returns>Employee exit details</returns>
        public EmployeeExitViewModel FetchEmployeeExitDetails(string empNo)
        {
            EmployeeExit employeeExitDetails = this.employeeRepository.FetchEmployeeExitDetails(empNo);
            return this.mapper.Map<EmployeeExitViewModel>(employeeExitDetails);
        }

        /// <summary>
        /// Fetches the feedback questions
        /// </summary>
        /// <returns>Feedback questions</returns>
        public List<FeedbackViewModel> FetchFeedbackQuestions()
        {
            List<Feedback> feedBack = this.employeeRepository.FetchFeedbackQuestions();
            return this.mapper.Map<List<FeedbackViewModel>>(feedBack);
        }

        /// <summary>
        /// Saves the employee exit details
        /// </summary>
        /// <param name="employeeExit">Employee exit data</param>
        /// <param name="employeeFeedback">employee feedback</param>
        /// <returns>Saved status</returns>
        public string SaveEmployeeExitDetails(EmployeeExitViewModel employeeExitData)
        {
            EmployeeExit employeeExit = this.mapper.Map<EmployeeExit>(employeeExitData);
            employeeExit.dtLastWorkingDate = DateTime.Today.AddDays(60);
            return this.employeeRepository.SaveEmployeeExitDetails(employeeExit, employeeExitData.Feedbacks);
        }
        public string UpdateAdminApprovals(string exitEmpNo, string adminRole)
        {
            string status=this.employeeRepository.UpdateAdminApprovals(exitEmpNo, adminRole);

            return status;
        }
    }
}
