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
        public string txtEmployeeNumber { get; set; }
        /// <summary>
        /// Gets or sets the mail id
        /// </summary>
        public string txtEmpMailId { get; set; }
        /// <summary>
        /// Gets or sets the personal email id
        /// </summary>
        public string txtEmpPersonalEmailid { get; set; }
        /// <summary>
        /// Gets or sets the contact number
        /// </summary>
        public string txtEmpContact { get; set; }
        /// <summary>
        /// Separation date
        /// </summary>
        public DateTime dtSeparationDate { get; set; }
        /// <summary>
        /// Gets or sets the last working day
        /// </summary>
        public DateTime dtLastWorkingDate { get; set; }
    }
}
