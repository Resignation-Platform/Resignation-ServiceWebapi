using Resignation_Service.Models;
using Resignation_Service.Utility.DataAccess;
using Resignation_Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Resignation_Service.Repository
{
    /// <summary>
    /// Employee repository class
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ICommon _common;
        public EmployeeRepository(ICommon common)
        {
            _common= common;

        }

        /// <summary>
        /// Fetches the employee details
        /// </summary>
        /// <param name="empName">Employee name</param>
        /// <returns>Employee details</returns>
        public Employee  FetchEmployeeDetail(string empName)
        {
            DataSet dataSetobj = new DataSet();
            SqlParameter[] arr_sqlParameter = new SqlParameter[1];
            List<Employee> empList = new List<Employee>();
            try
            {
                arr_sqlParameter[0] = new SqlParameter("@txtEmpName", SqlDbType.VarChar, 8);
                arr_sqlParameter[0].Value = empName;
                dataSetobj =  _common.ExecuteDSTimeout("spFetchEmployeeDetails", arr_sqlParameter);
                empList =  dataSetobj.Tables[0].AsEnumerable().Select(datarow =>new Employee
                {
                   txtEmpNo=datarow.Field<string>("txtEmpNo"),
                   txtEmpMailId=datarow.Field<string>("txtEmpMailId"),
                    txtEmpRole = datarow.Field<string>("txtEmpRole"),
                    txtDeptName = datarow.Field<string>("txtDeptName"),
                    dtDateOfJoining = datarow.Field<DateTime>("dtDateOfJoining"),
                    txtHR = datarow.Field<string>("txtHR"),
                    txtProgramManager = datarow.Field<string>("txtPM"),
                    txtDeliveryHead = datarow.Field<string>("txtDH"),

                }).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }


            return  empList.FirstOrDefault();
        }



        /// <summary>
        /// Fetches the feedback questions
        /// </summary>
        /// <returns>Feedback questions</returns>
        public List<Feedback> FetchFeedbackQuestions()
        {
            DataSet feedback_dataSet= new DataSet();
            List<Feedback> feedback_list = new List<Feedback>();
            SqlParameter[] arr_sqlParameter = new SqlParameter[0];           
            try
            {
                feedback_dataSet = _common.ExecuteDSTimeout("spFetchFeedbackQuestions", arr_sqlParameter);
                feedback_list = feedback_dataSet.Tables[0].AsEnumerable().Select(data => new Feedback
                {
                    intId= data.Field<int>("intId"),
                    txtQuestion=data.Field<string>("txtQuestion"),
                    txtOptions=data.Field<List<string>>("txtOptions")
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return feedback_list;
        }


        public string UpdateAdminApprovals(string exitEmpNo, string adminRole)
        {
            DataSet updateStatus_dataSet = new DataSet();
            string status=string.Empty;
            SqlParameter[] arr_sqlParameter = new SqlParameter[2];
            try
            {
                arr_sqlParameter[0] = new SqlParameter("@txtExitEmpNo", SqlDbType.VarChar, 8);
                arr_sqlParameter[0].Value = exitEmpNo;
                arr_sqlParameter[1] = new SqlParameter("@txtLoggedUserRole", SqlDbType.VarChar, 20);
                arr_sqlParameter[1].Value = adminRole;
                
                updateStatus_dataSet = _common.ExecuteDSTimeout("spUpdatetheAdminAcceptance", arr_sqlParameter);

               status = updateStatus_dataSet.Tables[0].Rows[0]["txtStatus"].ToString();
                    



            }
            catch (Exception)
            {

                throw;
            }


            return status;
        }

        /// <summary>
        /// Saves the employee exit details
        /// </summary>
        /// <param name="employeeExit">Employee exit data</param>
        /// <param name="employeeFeedback">employee feedback</param>
        /// <returns>Saved status</returns>
        public string SaveEmployeeExitDetails(EmployeeExit employeeExit, List<ExitFeedback> employeeFeedback)
        {
            SqlParameter[] arr_sqlParameter = new SqlParameter[2];
            DataSet SaveEmpdataObj= new DataSet();
            List<EmployeeExit> employeeExit_list = new List<EmployeeExit>();
            employeeExit_list.Add(new EmployeeExit() 
            {  txtEmployeeNumber=employeeExit.txtEmployeeNumber ,
                txtEmpMailId   =employeeExit.txtEmpMailId ,
                txtEmpPersonalEmailid  = employeeExit.txtEmpPersonalEmailid ,
                txtEmpContact   = employeeExit.txtEmpContact ,
               dtSeparationDate = employeeExit.dtSeparationDate ,
               dtLastWorkingDate = employeeExit.dtLastWorkingDate ,
            
            });
            string status = string.Empty;
            
            try
            {

                arr_sqlParameter[0] = new SqlParameter("@txtEmpData", SqlDbType.NVarChar);
                DataTable empExitData = this._common.ConvertToDataTable(employeeExit_list);
                XmlDocument empExitDataXML = this._common.ConverToXML(empExitData);
                arr_sqlParameter[0].Value= empExitDataXML.InnerXml;

                arr_sqlParameter[1]=new SqlParameter("@txtFeedbackdata", SqlDbType.NVarChar);
                DataTable empExitFeedbackData = this._common.ConvertToDataTable(employeeFeedback);
                XmlDocument empFeedbackDataXML = this._common.ConverToXML(empExitFeedbackData);
                arr_sqlParameter[1].Value= empFeedbackDataXML.InnerXml;
                SaveEmpdataObj = this._common.ExecuteDSTimeout("spSaveEmployeeExitDetails", arr_sqlParameter);
                status=SaveEmpdataObj.Tables[0].AsEnumerable().Select(row=>row.Field<string>("txtstatus")).ToString();

            }
            catch (Exception)
            {

                throw;
            }

            return status;
        }

    }
}
