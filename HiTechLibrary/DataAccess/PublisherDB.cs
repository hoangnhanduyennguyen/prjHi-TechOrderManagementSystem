using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HiTechLibrary.Business;

namespace HiTechLibrary.DataAccess
{
    public static class PublisherDB
    {
        //Method to search for a publisher by publisher id
        public static Publisher SearchRecord(int pubId)
        {
            SqlConnection connectDB = UtilityDB.ConnectDB();
            Publisher pub = new Publisher();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM Publishers WHERE PublisherId = @PublisherId", connectDB);
            cmdSearch.Parameters.AddWithValue("@PublisherId", pubId);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                pub.PublisherId = Convert.ToInt32(sqlRead["PublisherId"]);
                pub.PublisherName = sqlRead["PublisherName"].ToString();
                pub.WebAddress = sqlRead["WebAddress"].ToString();
            }
            else
            {
                pub = null;
            }

            return pub;
        }
        //Method to list all publishers
        public static List<Publisher> GetRecordList()
        {
            List<Publisher> listPub = new List<Publisher>();
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Select all operation
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Publishers", connDB);
            SqlDataReader sqlReader = cmdSelectAll.ExecuteReader();
            Publisher pub;
            while (sqlReader.Read())
            {
                pub = new Publisher();
                pub.PublisherId = Convert.ToInt32(sqlReader["PublisherId"]);
                pub.PublisherName = sqlReader["PublisherName"].ToString();
                pub.WebAddress = sqlReader["WebAddress"].ToString();
                listPub.Add(pub);

            }
            // Step 3: Close the database 
            connDB.Close();
            return listPub;
        }
    }
}
