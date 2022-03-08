using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resignation_Service.Models
{
    public class EmployeeExit
    {
        /// <summary>
        /// Gets or sets the employee number
        /// </summary>
        public string txtEmpNo { get; set; }

        /// <summary>
        /// Gets or sets the employee email
        /// </summary>
        public string txtEmpId { get; set; }

        /// <summary>
        /// Gets or sets the employee personal email
        /// </summary>
        public string txtEmpPersonalId { get; set; }

        /// <summary>
        /// Gets or sets the employee contact number
        /// </summary>
        public string txtcontact { get; set; }

        /// <summary>
        /// Gets or sets the date of Separation 
        /// </summary>
        public DateTime dtSeperationdate { get; set; }

        /// <summary>
        /// Gets or sets the last working date
        /// </summary>
        public DateTime dtLastWorkingDate { get; set; }

        /// <summary>
        /// Gets or sets the HR approval status
        /// </summary>
        public char flgIsHrApproved { get; set; }

        /// <summary>
        /// Gets or sets the PM approval status
        /// </summary>
        public char flgIsPmApproed { get; set; }

        // <summary>
        /// Gets or sets the DH approval status
        /// </summary>
        public char flgisDHApproved { get; set; }

        /// <summary>
        /// Gets or sets the IT clearance status
        /// </summary>
        public char flgITClearance { get; set; }

        // <summary>
        /// Gets or sets the finance clearance status
        /// </summary>
        public char flgFinanceClearance { get; set; }
    }
    public class FeedbackModel
    {
        public string txtQuestions { get; set; }
        public string txtAnswers { get; set; }
    }
}
