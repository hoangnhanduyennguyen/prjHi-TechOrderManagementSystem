using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechLibrary.Business;
using System.Data.SqlClient;

namespace HiTechLibrary.DataAccess
{
    public static class StatusDB
    {
        //Method to list all statues
        public static List<Status> GetRecordList(string select)
        {
            List<Status> listStatus = new List<Status>();
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Select all operation
            SqlCommand cmdSelectAll;
            SqlDataReader sqlReader;
            if (select == "Customer")//|| select == "UserAccount"
            {
                cmdSelectAll = new SqlCommand("SELECT * FROM Statuses WHERE Id = 5", connDB); // OR Id = 6
                sqlReader = cmdSelectAll.ExecuteReader();
                Status status;
                while (sqlReader.Read())
                {
                    status = new Status();
                    status.Id = Convert.ToInt32(sqlReader["Id"]);
                    status.Description = sqlReader["Description"].ToString();
                    listStatus.Add(status);
                }
            }else if (select == "Book")
            {
                cmdSelectAll = new SqlCommand("SELECT * FROM Statuses WHERE Id = 8 OR Id = 10 OR Id = 11", connDB);
                sqlReader = cmdSelectAll.ExecuteReader();
                Status status;
                while (sqlReader.Read())
                {
                    status = new Status();
                    status.Id = Convert.ToInt32(sqlReader["Id"]);
                    status.Description = sqlReader["Description"].ToString();
                    listStatus.Add(status);
                }
            }
            // Step 3: Close the database 
            connDB.Close();
            return listStatus;
        }

    }
}
