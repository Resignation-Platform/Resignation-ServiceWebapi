using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace Resignation_Service.Utility.DataAccess
{
    public class Common: ICommon
    {
        string sConString = Startup.ConnectionString;
        public  DataSet ExecuteDSTimeout(string SP, SqlParameter[] arr_sqlParam)
        {
            DataSet dsData = new DataSet();
            SqlConnection scon = new SqlConnection(sConString);
            SqlCommand cmd = new SqlCommand(SP, scon);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            try
            {
                scon.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < arr_sqlParam.Length; i++)
                {
                    cmd.Parameters.Add(arr_sqlParam[i]);
                }
                cmd.CommandTimeout = 400;
                 sqlDataAdapter.Fill(dsData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                scon.Close();
            }
              return dsData;
        }

        public DataTable GetDataTable(string strQry)
        {
            DataTable dtTable = new DataTable();
            try
            {
                using (SqlConnection objCon = new SqlConnection(sConString))
                {
                    using (SqlCommand objCmd = new SqlCommand(strQry, objCon))
                    {
                        using (SqlDataAdapter objda = new SqlDataAdapter(objCmd))
                        {
                            objda.Fill(dtTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtTable;
        }

        public DataTable ConvertToDataTable<T>(List<T> varlist)
        {
            DataTable dtReturn = new DataTable();
            // column names
            PropertyInfo[] oProps = null;
            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow
                if (oProps == null)
                {
                    oProps = rec.GetType().GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                DataRow dr = dtReturn.NewRow();
                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }
                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public XmlDocument ConverToXML(DataTable dtdata)
        {
            var objXML = new XmlDocument();
            XmlElement objRoot;
            XmlElement objData;

            if (dtdata.Rows.Count == 0 || dtdata == null)
            {
                objRoot = objXML.CreateElement("Data");
                objXML.AppendChild(objRoot);
                objData = objXML.CreateElement("Details");
                objRoot.AppendChild(objData);
                return objXML;
            }
            else if (dtdata.Rows.Count > 0 && dtdata.Columns.Count > 0)
            {
                objRoot = objXML.CreateElement("Data");
                objXML.AppendChild(objRoot);
                for (int i = 0; i < dtdata.Rows.Count; i++)
                {
                    objData = objXML.CreateElement("Details");
                    objRoot.AppendChild(objData);
                    for (int j = 0; j < dtdata.Columns.Count; j++)
                    {
                        objData.SetAttribute(dtdata.Columns[j].ToString().Trim(), dtdata.Rows[i][j].ToString().Trim());
                    }
                }
            }
            return objXML;
        }
    }
}
