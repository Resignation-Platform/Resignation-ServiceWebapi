using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace Resignation_Service.Utility.DataAccess
{
    public interface ICommon
    {
        public DataSet ExecuteDSTimeout(string SP, SqlParameter[] arr_sqlParam);
        public DataTable GetDataTable(string strQry);
        public DataTable ConvertToDataTable<T>(List<T> varlist);
        public XmlDocument ConverToXML(DataTable dtdata);
    }
}
