using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HiTechLibrary.Business;

namespace HiTechLibrary.DataAccess
{
    public static class CategoryDB
    {
        //Method to search for a category by category id
        public static Category SearchRecord(int catId)
        {
            SqlConnection connectDB = UtilityDB.ConnectDB();
            Category cate = new Category();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM Categories WHERE CategoryId = @CategoryId", connectDB);
            cmdSearch.Parameters.AddWithValue("@CategoryId", catId);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                cate.CategoryId = Convert.ToInt32(sqlRead["CategoryId"]);
                cate.CategoryName = sqlRead["CategoryName"].ToString();
            }
            else
            {
                cate = null;
            }

            return cate;
        }
        //Method to list all categories
        public static List<Category> GetRecordList()
        {
            List<Category> listCat = new List<Category>();
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Select all operation
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Categories", connDB);
            SqlDataReader sqlReader = cmdSelectAll.ExecuteReader();
            Category cat;
            while (sqlReader.Read())
            {
                cat = new Category();
                cat.CategoryId = Convert.ToInt32(sqlReader["CategoryId"]);
                cat.CategoryName = sqlReader["CategoryName"].ToString();
                listCat.Add(cat);

            }
            // Step 3: Close the database 
            connDB.Close();
            return listCat;
        }

    }
}
