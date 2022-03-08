using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resignation_Service.ViewModels
{
    public class EmployeeViewModel
    {
        /// <summary>
        /// Gets or sets the employee number
        /// </summary>
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the employee email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the employee role
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the employee department name
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the date of joining
        /// </summary>
        public DateTime DateOfJoining { get; set; }

        /// <summary>
        /// Gets or sets the name of HR
        /// </summary>
        public string HRName { get; set; }

        /// <summary>
        /// Gets or sets the program manager name
        /// </summary>
        public string ProgramManagerName { get; set; }

        /// <summary>
        /// Gets or sets the delivery leader name
        /// </summary>
        public string DeliveryLeaderName { get; set; }
    }
}
