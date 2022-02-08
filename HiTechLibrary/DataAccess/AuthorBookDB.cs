using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechLibrary.Business;
using System.Data.SqlClient;

namespace HiTechLibrary.DataAccess
{
    public static class AuthorBookDB
    {
        public static void SaveRecord(AuthorBook aub)
        {
            // Step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Insert operation
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO AuthorsBooks VALUES(@AuthorId,@ISBN,@YearPublished,@Edition);", connDB);
            cmdInsert.Parameters.AddWithValue("@AuthorId", aub.AuthorId);
            cmdInsert.Parameters.AddWithValue("@ISBN", aub.ISBN);
            cmdInsert.Parameters.AddWithValue("@YearPublished", aub.YearPublished);
            cmdInsert.Parameters.AddWithValue("@Edition", aub.Edition);
            cmdInsert.ExecuteNonQuery();
            // Step 3: Close the DB
            connDB.Close();
        }
        public static void UpdateRecord(AuthorBook aub)
        {
            //step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //step 2: Perform Update operation 
            SqlCommand cmdUpdate = new SqlCommand("UPDATE AuthorsBooks SET YearPublished = @YearPublished, Edition = @Edition WHERE ISBN = @ISBN", connDB);
            cmdUpdate.Parameters.AddWithValue("@ISBN", aub.ISBN);
            cmdUpdate.Parameters.AddWithValue("@YearPublished", aub.YearPublished);
            cmdUpdate.Parameters.AddWithValue("@Edition", aub.Edition);
            cmdUpdate.ExecuteNonQuery();
            //step 3: Close DB
            connDB.Close();
        }
        public static void DeleteRecord(int authorId, string iSBN)
        {
            //step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //step 2: Perform Delete operation 
            SqlCommand cmdDelete = new SqlCommand("DELETE FROM AuthorsBooks WHERE ISBN = @ISBN AND AuthorId = @authorId", connDB);
            cmdDelete.Parameters.AddWithValue("@ISBN", iSBN);
            cmdDelete.Parameters.AddWithValue("@authorId", authorId);
            cmdDelete.ExecuteNonQuery();
            //step 3: Close DB
            connDB.Close();
        }
        public static List<AuthorBook> GetListRecord(string iSBN)
        {
            List<AuthorBook> listAuBook = new List<AuthorBook>();
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Select all operation
            SqlCommand cmdSelectTitle = new SqlCommand("SELECT * FROM AuthorsBooks " + "WHERE ISBN = @iSBN ", connDB);
            cmdSelectTitle.Parameters.AddWithValue("@iSBN", iSBN);
            SqlDataReader sqlReader = cmdSelectTitle.ExecuteReader();
            AuthorBook auBook;
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    auBook = new AuthorBook();
                    auBook.ISBN = sqlReader["ISBN"].ToString();
                    auBook.AuthorId = Convert.ToInt32(sqlReader["AuthorId"].ToString());
                    auBook.Edition = sqlReader["Edition"].ToString();
                    auBook.YearPublished = sqlReader["YearPublished"].ToString();
                    listAuBook.Add(auBook);
                }
            }
            else
            {
                listAuBook = null;
            }
            // Step 3: CLose the Database
            connDB.Close();
            return listAuBook;
        }
        public static List<AuthorBook> GetListRecord(int authorId)
        {
            List<AuthorBook> listAuBook = new List<AuthorBook>();
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Select all operation
            SqlCommand cmdSelectTitle = new SqlCommand("SELECT * FROM AuthorsBooks " + "WHERE AuthorId = @authorId ", connDB);
            cmdSelectTitle.Parameters.AddWithValue("@authorId", authorId);
            SqlDataReader sqlReader = cmdSelectTitle.ExecuteReader();
            AuthorBook auBook;
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    auBook = new AuthorBook();
                    auBook.ISBN = sqlReader["ISBN"].ToString();
                    auBook.AuthorId = Convert.ToInt32(sqlReader["AuthorId"].ToString());
                    auBook.Edition = sqlReader["Edition"].ToString();
                    auBook.YearPublished = sqlReader["YearPublished"].ToString();
                    listAuBook.Add(auBook);
                }
            }
            else
            {
                listAuBook = null;
            }
            // Step 3: CLose the Database
            connDB.Close();
            return listAuBook;
        }
        public static AuthorBook GetRecord(int auId, string iSBN)
        {
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            //Step 2: Perform Search operation
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM AuthorsBooks WHERE AuthorId = @auId AND ISBN = @iSBN", connDB);
            cmdSelect.Parameters.AddWithValue("@auId", auId);
            cmdSelect.Parameters.AddWithValue("@iSBN", iSBN);
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            AuthorBook auBo = new AuthorBook();
            if (sqlReader.Read())
            {
                auBo.AuthorId = Convert.ToInt32(sqlReader["AuthorId"]);
                auBo.ISBN = sqlReader["ISBN"].ToString();
                auBo.Edition = sqlReader["Edition"].ToString();
                auBo.YearPublished = sqlReader["YearPublished"].ToString();
            }
            else
            {
                auBo = null;

            }
            // Step 3: Close the database
            connDB.Close();
            return auBo;
        }
    }
}
