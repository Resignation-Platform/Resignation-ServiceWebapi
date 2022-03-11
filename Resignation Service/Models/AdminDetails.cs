using System;

namespace Resignation_Service.Models
{
    public class AdminDetails
    {
        public string txtEmployeeNo { get; set; }
        public string txtEmpEmailId { get; set; }
        public string txtEmpPersonalEmailid { get; set; }
        public string txtEmpContact { get; set; }
        public DateTime dtSeperationDate { get; set; }
        public DateTime dtLastWorkingDate { get; set; }
        public string flgIsHrApproved { get; set; }
    }
}
