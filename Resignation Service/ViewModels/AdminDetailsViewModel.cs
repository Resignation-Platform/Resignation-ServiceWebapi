using System;

namespace Resignation_Service.ViewModels
{
    public class AdminDetailsViewModel
    {
        public string EmployeeNo { get; set; }
        public string EmployeeEmailId { get; set; }
        public string EmployeePersonalEmailid { get; set; }
        public string EmployeeContact { get; set; }
        public DateTime SeperationDate { get; set; }
        public DateTime LastWorkingDate { get; set; }
        public string IsHrApproved { get; set; }
    }
}
