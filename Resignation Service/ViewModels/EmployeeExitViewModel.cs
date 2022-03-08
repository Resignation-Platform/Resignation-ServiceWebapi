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
        /// Gets or sets the employee email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the employee personal email
        /// </summary>
        public string PersonalEmail { get; set; }

        /// <summary>
        /// Gets or sets the employee contact number
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// Gets or sets the date of Separation 
        /// </summary>
        public DateTime SeparationDate { get; set; }

        /// <summary>
        /// Gets or sets the last working date
        /// </summary>
        public DateTime LastWorkingDate { get; set; }

        /// <summary>
        /// Gets or sets the HR approval status
        /// </summary>
        public bool IsHRApproved { get; set; }

        /// <summary>
        /// Gets or sets the PM approval status
        /// </summary>
        public bool IsPMApproved { get; set; }

        // <summary>
        /// Gets or sets the DH approval status
        /// </summary>
        public bool IsDHApproved { get; set; }

        /// <summary>
        /// Gets or sets the IT clearance status
        /// </summary>
        public bool ITClearance { get; set; }

        // <summary>
        /// Gets or sets the finance clearance status
        /// </summary>
        public bool FinanceClearance { get; set; }
    }
}
