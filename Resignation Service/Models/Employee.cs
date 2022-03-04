using System;


namespace Resignation_Service.Models
{
    public class Employee
    {
        /// <summary>
        /// Gets or sets the employee number
        /// </summary>
        public string txtEmpNo { get; set; }
        /// <summary>
        /// Gets or sets the employee email
        /// </summary>
        public string txtEmpMailId { get; set; }
        /// <summary>
        /// Gets or sets the employee role
        /// </summary>
        public string txtEmpRole { get; set; }
        /// <summary>
        /// Gets or sets the employee department name
        /// </summary>
        public string txtDeptName { get; set; }
        /// <summary>
        /// Gets or sets the date of joining
        /// </summary>
        public DateTime dtDateOfJoining { get; set; }
        /// <summary>
        /// Gets or sets the name of HR
        /// </summary>
        public string txtHR { get; set; }
        /// <summary>
        /// Gets or sets the program manager name
        /// </summary>
        public string txtProgramManager { get; set; }
        /// <summary>
        /// Gets or sets the delivery leader name
        /// </summary>
        public string txtDeliveryHead { get; set; }
    }
}
