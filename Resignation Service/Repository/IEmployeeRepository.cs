using Resignation_Service.Models;
using Resignation_Service.ViewModels;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Resignation_Service.Repository
{
    /// <summary>
    /// Interface for the employee repository
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Fetches the employee details
        /// </summary>
        /// <param name="empName">Employee name</param>
        /// <returns>Employee details</returns>
        public Employee FetchEmployeeDetail(string empName);
        /// <summary>
        /// Fetches the feedback questions
        /// </summary>
        /// <returns>Feedback questions</returns>
        public List<Feedback> FetchFeedbackQuestions();

        /// <summary>
        /// Fetches the employee exit details
        /// </summary>
        /// <param name="empNo">Employee Number</param>
        /// <returns>Employee exit details</returns>
        public EmployeeExit FetchEmployeeExitDetails(string empNo);

        /// <summary>
        /// Saves the employee exit details
        /// </summary>
        /// <param name="employeeExit">Employee exit data</param>
        /// <param name="employeeFeedback">employee feedback</param>
        /// <returns>Saved status</returns>
        public string SaveEmployeeExitDetails(EmployeeExit employeeExit, List<ExitFeedback> employeeFeedback);

        public string UpdateAdminApprovals(string exitEmpNo, string adminRole);
    }
}
