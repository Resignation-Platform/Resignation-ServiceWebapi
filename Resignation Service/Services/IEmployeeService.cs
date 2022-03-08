using Resignation_Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resignation_Service.Services
{
    /// <summary>
    /// Interface for the employee service
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Fetches the employee details
        /// </summary>
        /// <param name="empName">Employee name</param>
        /// <returns>Employee details</returns>
        public EmployeeViewModel FetchEmployeeDetail(string empName);

        /// <summary>
        /// Fetches the employee exit details
        /// </summary>
        /// <param name="empNo">Employee Number</param>
        /// <returns>Employee details</returns>
        public EmployeeExitViewModel FetchEmployeeExitDetails(string empNo);

        /// <summary>
        /// Fetchs the feedback questions
        /// </summary>
        /// <returns>Feedback questions</returns>
        public List<FeedbackViewModel> FetchFeedbackQuestions();

        /// <summary>
        /// Saves the employee exit details
        /// </summary>
        /// <returns>Saved status</returns>
        public string SaveEmployeeExitDetails(EmployeeExitDetailsViewModel employeeExitData);


        public string UpdateAdminApprovals(string exitEmpNo, string adminRole);
    }
}
