using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resignation_Service.ViewModels
{
    public class EmployeeExitViewModel
    {
        /// <summary>
        /// Gets or sets the employee number
        /// </summary>
        public string EmployeeNumber { get; set; }
        /// <summary>
        /// Gets or sets the mail id
        /// </summary>
        public string MailId { get; set; }
        /// <summary>
        /// Gets or sets the personal email id
        /// </summary>
        public string PersonalEmailId { get; set; }
        /// <summary>
        /// Gets or sets the contact number
        /// </summary>
        public string ContactNumber { get; set; }
        /// <summary>
        /// Separation date
        /// </summary>
        public DateTime SeparationDate { get; set; }
        /// <summary>
        /// Gets or sets the last working day
        /// </summary>
        public DateTime LastWorkingDay { get; set; }
        /// <summary>
        /// Gets or sets the feed back question
        /// </summary>
        public List<ExitFeedback> Feedbacks { get; set; }
    }
}
