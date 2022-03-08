using System;

namespace Resignation_Service.Models
{
    public class EmployeeExitDetails
    {
        public string txtEmployeeNumber { get; set; }
        
        public string txtEmpMailId { get; set; }
        
        public string txtEmpPersonalEmailid { get; set; }
        
        public string txtEmpContact { get; set; }
        
        public DateTime dtSeparationDate { get; set; }
        
        public DateTime dtLastWorkingDate { get; set; }
        //public List<FeedbackModel> txtFeedback { get; set; }
    }
}
