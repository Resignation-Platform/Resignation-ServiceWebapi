using System;
using System.Collections.Generic;

namespace Resignation_Service.ViewModels
{
    public class EmployeeExitDetailsViewModel
    {
        
        public string EmployeeNumber { get; set; }
       
        public string MailId { get; set; }
        
        public string PersonalEmailId { get; set; }
        
        public string ContactNumber { get; set; }
        
        public DateTime SeparationDate { get; set; }
        
        public DateTime LastWorkingDay { get; set; }
        
        public List<ExitFeedback> Feedbacks { get; set; }
    }
}
