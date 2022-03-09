using Resignation_Service.Models;
using System;
using Resignation_Service.ViewModels;
using System.Collections.Generic;

namespace Resignation_Service_Test.Helper
{
    public static class MockData
    {
        /// <summary>
        /// Fetchs the employee details
        /// </summary>
        /// <returns></returns>
        public static EmployeeViewModel FetchEmployeeDetails()
        {
            return new EmployeeViewModel()
            {
                EmployeeNumber = "1234",
                Email = "Test@gmail.com",
                Role = "Developer",
                DepartmentName = "Engineering",
                HRName = "TestName",
                DeliveryLeaderName = "TestName2",
                ProgramManagerName = "TestName3"
            };
        }

        public static Employee FetchEmployeeData()
        {
            return new Employee()
            {
                txtEmpNo = "1234",
                txtEmpMailId = "Test@gmail.com",
                txtEmpRole = "Developer",
                txtDeptName = "Engineering",
                txtHR = "TestName",
                txtDeliveryHead = "TestName2",
                txtProgramManager = "TestName3"
            };
        }

        public static List<AdminDetails> FetchAdminData()
        {
            return new List<AdminDetails>()
            {
                new AdminDetails()
                {
                    txtEmployeeNo="1024",
                    txtEmpEmailId="test@gmail.com",
                    txtEmpPersonalEmailid="test1@gmail.com",
                    txtEmpContact="987653255",
                    dtSeperationDate=DateTime.Now,
                    dtLastWorkingDate=DateTime.Now
                }
            };
        }
        public static List<AdminDetailsViewModel> FetchAdminViewData()
        {
            return new List<AdminDetailsViewModel>()
            {
                new AdminDetailsViewModel()
                {
                    EmployeeNo="1024",
                    EmployeeEmailId="test@gmail.com",
                    EmployeePersonalEmailid="test1@gmail.com",
                    EmployeeContact="987653255",
                    SeperationDate= DateTime.Now,
                    LastWorkingDate= DateTime.Now
                }
            };
        }
        public static List<FeedbackViewModel> FetchFeedbackViewData()
        {
            return new List<FeedbackViewModel>()
            {
                new FeedbackViewModel()
                {
                    FeedbackId = 1,
                    FeedbackQuestion = "What is the reason for resignation?",
                    Options = new List<string>() { "Salary", "Culture" }
                }
            };
        }

        public static List<Feedback> FetchFeedbackData()
        {
            return new List<Feedback>()
            {
                new Feedback()
                {
                    intId = 1,
                    txtQuestion = "What is the reason for resignation?",
                    txtOptions = new List<string>() { "Salary", "Culture" }
                }
            };
        }

        /// <summary>
        /// Gets the employee exit data
        /// </summary>
        /// <returns>Employee exit data</returns>
        public static EmployeeExitDetailsViewModel GetEmployeeExitData()
        {
            return new EmployeeExitDetailsViewModel()
            {
                EmployeeNumber = "737473",
                MailId = "test1@gmail.com",
                PersonalEmailId = "test2@gmail.com",
                ContactNumber = "993994322",
                SeparationDate = DateTime.Parse("2022-03-04"),
                LastWorkingDay = DateTime.Parse("2022-05-04"),
                Feedbacks = new List<ExitFeedbackViewModel>()
                {
                    new ExitFeedbackViewModel()
                    {
                        Question = "What is the reason for resignation?",
                        Answer = "Culture"
                    }
                }
            };
        }
        public static string UpdateAdminActions()
        {
            return "Updated successfully";
        }
    }
}
