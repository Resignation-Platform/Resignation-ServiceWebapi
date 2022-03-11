using Resignation_Service.Models;
using Resignation_Service.Utility.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Resignation_Service.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ICommon _common;
        public AdminRepository()
        {
            _common = new Common();

        }
        public List<AdminDetails> FetchDetailsForAdmin(string AdminEmpNo, string AdminRole)
        {
            SqlParameter[] arr_sqlParameter = new SqlParameter[2];
            DataSet adminDsObj= new DataSet();
            List<AdminDetails> adminDetails = new List<AdminDetails>(); 
            try
            {
                arr_sqlParameter[0] = new SqlParameter("@txtEmpNo", SqlDbType.VarChar, 8);
                arr_sqlParameter[0].Value = AdminEmpNo;
                arr_sqlParameter[1] = new SqlParameter("@txtRole", SqlDbType.VarChar, 20);
                arr_sqlParameter[1].Value = AdminRole;
                adminDsObj = this._common.ExecuteDSTimeout("spFetchAdminDetails", arr_sqlParameter);
                adminDetails=adminDsObj.Tables[0].AsEnumerable().Select(data=>new AdminDetails
                {
                    txtEmployeeNo=data.Field<string>("txtEmployeeNo"),
                    txtEmpEmailId = data.Field<string>("txtEmpEmailId"),
                    txtEmpPersonalEmailid=data.Field<string>("txtEmpPersonalEmailid"),
                    txtEmpContact=data.Field<string>("txtEmpContact"),
                    dtSeperationDate=data.Field<DateTime>("dtSeperationDate"),
                    dtLastWorkingDate=data.Field<DateTime>("dtLastWorkingDate"),
                    flgIsHrApproved=data.Field<string>("flgIsHrApproved")
                }).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
            return adminDetails;
        }
    }
}
