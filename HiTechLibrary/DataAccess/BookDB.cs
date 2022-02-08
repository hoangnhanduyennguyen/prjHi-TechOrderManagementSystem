using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HiTechLibrary.Business;

namespace HiTechLibrary.DataAccess
{
    public static class BookDB
    {
        public static void SaveRecord(Book book)
        {
            // Step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Insert operation
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Books VALUES(@ISBN,@BookTitle,@UnitPrice,@QOH,@PublisherId,@CategoryId,@Status);", connDB);
            cmdInsert.Parameters.AddWithValue("@ISBN", book.ISBN);
            cmdInsert.Parameters.AddWithValue("@BookTitle", book.BookTitle);
            cmdInsert.Parameters.AddWithValue("@UnitPrice", book.UnitPrice);
            cmdInsert.Parameters.AddWithValue("@QOH", book.QOH);
            cmdInsert.Parameters.AddWithValue("@PublisherId", book.PublisherId);
            cmdInsert.Parameters.AddWithValue("@CategoryId", book.CategoryId);
            cmdInsert.Parameters.AddWithValue("@Status", book.Status);
            cmdInsert.ExecuteNonQuery();
            // Step 3: Close the DB
            connDB.Close();
        }
        // Method to update book information
        public static void UpdateRecord(Book book)
        {
            //step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //step 2: Perform Update operation 
            SqlCommand cmdUpdate = new SqlCommand("UPDATE Books SET BookTitle = @BookTitle, UnitPrice = @UnitPrice, QOH = @QOH, PublisherId = @PublisherId, CategoryId = @CategoryId, Status = @Status WHERE ISBN = @ISBN", connDB);
            cmdUpdate.Parameters.AddWithValue("@ISBN", book.ISBN);
            cmdUpdate.Parameters.AddWithValue("@BookTitle", book.BookTitle);
            cmdUpdate.Parameters.AddWithValue("@UnitPrice", book.UnitPrice);
            cmdUpdate.Parameters.AddWithValue("@QOH", book.QOH);
            cmdUpdate.Parameters.AddWithValue("@PublisherId", book.PublisherId);
            cmdUpdate.Parameters.AddWithValue("@CategoryId", book.CategoryId);
            cmdUpdate.Parameters.AddWithValue("@Status", book.Status);
            cmdUpdate.ExecuteNonQuery();
            //step 3: Close DB
            connDB.Close();
        }

        // Method to delete a book
        public static void DeleteRecord(string iSBN)
        {
            //step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //step 2: Perform Delete operation 
            SqlCommand cmdDelete = new SqlCommand("DELETE FROM Books WHERE ISBN = @ISBN", connDB);
            cmdDelete.Parameters.AddWithValue("@ISBN", iSBN);
            cmdDelete.ExecuteNonQuery();
            //step 3: Close DB
            connDB.Close();
        }

        // Method to search for a book by ISBN
        public static Book GetRecord(string iSBN)
        {
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            //Step 2: Perform Search operation
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Books WHERE ISBN = @ISBN", connDB);
            cmdSelect.Parameters.AddWithValue("@ISBN", iSBN);
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Book book = new Book();
            if (sqlReader.Read())
            {
                book.ISBN = sqlReader["ISBN"].ToString();
                book.BookTitle = sqlReader["BookTitle"].ToString();
                book.UnitPrice = Convert.ToDecimal(sqlReader["UnitPrice"]);
                book.QOH = Convert.ToInt32(sqlReader["QOH"]);
                book.PublisherId = Convert.ToInt32(sqlReader["PublisherId"]);
                book.CategoryId = Convert.ToInt32(sqlReader["CategoryId"]);
                book.Status = Convert.ToInt32(sqlReader["Status"]);
            }
            else
            {
                book = null;

            }
            // Step 3: Close the database
            connDB.Close();
            return book;
        }

        // Method to list all books
        public static List<Book> GetRecord()
        {
            List<Book> listBook = new List<Book>();
            Book book;
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchAll = new SqlCommand("SELECT * FROM Books", conn);
            SqlDataReader sqlReader = cmdSearchAll.ExecuteReader();
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    book = new Book();
                    book.ISBN = sqlReader["ISBN"].ToString();
                    book.BookTitle = sqlReader["BookTitle"].ToString();
                    book.UnitPrice = Convert.ToDecimal(sqlReader["UnitPrice"].ToString());
                    book.QOH = Convert.ToInt32(sqlReader["QOH"].ToString());
                    book.PublisherId = Convert.ToInt32(sqlReader["PublisherId"].ToString());
                    book.CategoryId = Convert.ToInt32(sqlReader["CategoryId"].ToString());
                    book.Status = Convert.ToInt32(sqlReader["Status"].ToString());
                    listBook.Add(book);
                }
            }
            else
            {
                listBook = null;
            }
            return listBook;
        }

        // Method to list books by book title
        public static List<Book> GetRecordByTitle(string title)
        {
            List<Book> listBook = new List<Book>();
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Select all operation
            SqlCommand cmdSelectTitle = new SqlCommand("SELECT * FROM Books " + "WHERE BookTitle = @BookTitle ", connDB);
            cmdSelectTitle.Parameters.AddWithValue("@BookTitle", title);
            SqlDataReader sqlReader = cmdSelectTitle.ExecuteReader();
            Book book;
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    book = new Book();
                    book.ISBN = sqlReader["ISBN"].ToString();
                    book.BookTitle = sqlReader["BookTitle"].ToString();
                    book.UnitPrice = Convert.ToDecimal(sqlReader["UnitPrice"].ToString());
                    book.QOH = Convert.ToInt32(sqlReader["QOH"].ToString());
                    book.PublisherId = Convert.ToInt32(sqlReader["PublisherId"].ToString());
                    book.CategoryId = Convert.ToInt32(sqlReader["CategoryId"].ToString());
                    book.Status = Convert.ToInt32(sqlReader["Status"].ToString());
                    listBook.Add(book);
                }
            }
            else
            {
                listBook = null;
            }
            // Step 3: CLose the Database
            connDB.Close();
            return listBook;
        }
        // Method to list books by book category id or publisher id
        public static List<Book> GetRecord(int id, string select)
        {
            List<Book> listBook = new List<Book>();
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Select all operation
            SqlCommand cmdSelectTitle = new SqlCommand("SELECT * FROM Books " + "WHERE "+ select + " = @id ", connDB);
            cmdSelectTitle.Parameters.AddWithValue("@id", id);
            SqlDataReader sqlReader = cmdSelectTitle.ExecuteReader();
            Book book;
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    book = new Book();
                    book.ISBN = sqlReader["ISBN"].ToString();
                    book.BookTitle = sqlReader["BookTitle"].ToString();
                    book.UnitPrice = Convert.ToDecimal(sqlReader["UnitPrice"].ToString());
                    book.QOH = Convert.ToInt32(sqlReader["QOH"].ToString());
                    book.PublisherId = Convert.ToInt32(sqlReader["PublisherId"].ToString());
                    book.CategoryId = Convert.ToInt32(sqlReader["CategoryId"].ToString());
                    book.Status = Convert.ToInt32(sqlReader["Status"].ToString());
                    listBook.Add(book);
                }
            }
            else
            {
                listBook = null;
            }
            // Step 3: CLose the Database
            connDB.Close();
            return listBook;
        }

    }
}
