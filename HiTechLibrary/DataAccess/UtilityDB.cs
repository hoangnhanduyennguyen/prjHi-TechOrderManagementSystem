using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace HiTechLibrary.DataAccess
{
    public static class UtilityDB
    {
        // Connect to HiTechDB Database
        public static SqlConnection ConnectDB()
        {
            SqlConnection connDB = new SqlConnection();
            connDB.ConnectionString = ConfigurationManager.ConnectionStrings["HiTechDB_Connection"].ConnectionString;
            connDB.Open();
            return connDB;
        }

    }
}
