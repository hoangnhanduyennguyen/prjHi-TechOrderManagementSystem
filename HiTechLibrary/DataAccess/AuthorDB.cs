using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechLibrary.Business;
using System.Data.SqlClient;

namespace HiTechLibrary.DataAccess
{
    public static class AuthorDB
    {
        // Method to add an author
        public static void SaveRecord(Author au)
        {
            // Step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Insert operation
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Authors VALUES(@AuthorId,@FirstName,@LastName,@Email);", connDB);
            cmdInsert.Parameters.AddWithValue("@AuthorId", au.AuthorId);
            cmdInsert.Parameters.AddWithValue("@FirstName", au.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", au.LastName);
            cmdInsert.Parameters.AddWithValue("@Email", au.Email);
            cmdInsert.ExecuteNonQuery();
            // Step 3: Close the DB
            connDB.Close();
        }
        // Method to update author information
        public static void UpdateRecord(Author au)
        {
            //step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //step 2: Perform Update operation 
            SqlCommand cmdUpdate = new SqlCommand("UPDATE Authors SET FirstName = @FirstName, LastName = @LastName, Email = @Email WHERE AuthorId = @AuthorId", connDB);
            cmdUpdate.Parameters.AddWithValue("@AuthorId", au.AuthorId);
            cmdUpdate.Parameters.AddWithValue("@FirstName", au.FirstName);
            cmdUpdate.Parameters.AddWithValue("@LastName", au.LastName);
            cmdUpdate.Parameters.AddWithValue("@Email", au.Email);
            cmdUpdate.ExecuteNonQuery();
            //step 3: Close DB
            connDB.Close();
        }
        // Method to delete an author
        public static void DeleteRecord(int auId)
        {
            //step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //step 2: Perform Delete operation 
            SqlCommand cmdDelete = new SqlCommand("DELETE FROM Authors WHERE AuthorId = @auId", connDB);
            cmdDelete.Parameters.AddWithValue("@auId", auId);
            cmdDelete.ExecuteNonQuery();
            //step 3: Close DB
            connDB.Close();
        }

        // Method to search for an author by author id
        public static Author GetRecord(int auId)
        {
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            //Step 2: Perform Search operation
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Authors WHERE AuthorId = @auId", connDB);
            cmdSelect.Parameters.AddWithValue("@auId", auId);
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Author au = new Author();
            if (sqlReader.Read())
            {
                au.AuthorId = Convert.ToInt32(sqlReader["AuthorId"]);
                au.FirstName = sqlReader["FirstName"].ToString();
                au.LastName = sqlReader["LastName"].ToString();
                au.Email = sqlReader["Email"].ToString();
            }
            else
            {
                au = null;

            }
            // Step 3: Close the database
            connDB.Close();
            return au;
        }
    }
}
