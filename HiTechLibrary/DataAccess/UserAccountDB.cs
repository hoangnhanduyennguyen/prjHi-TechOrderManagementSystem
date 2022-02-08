using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HiTechLibrary.Business;

namespace HiTechLibrary.DataAccess
{
    public static class UserAccountDB
    {
        // Method for user to login 
        public static UserAccount SearchRecord(int userId, string password)
        {
            SqlConnection connectDB = UtilityDB.ConnectDB();
            UserAccount user = new UserAccount();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM UserAccounts WHERE UserId = @UserId AND Password = @Password", connectDB);
            cmdSearch.Parameters.AddWithValue(@"UserId", userId);
            cmdSearch.Parameters.AddWithValue(@"Password", password);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                user.EmployeeId = Convert.ToInt32(sqlRead["EmployeeId"]);
                user.Password = sqlRead["Password"].ToString();
                user.UserId = Convert.ToInt32(sqlRead["UserId"]);
            }
            else
            {
                user = null;
            }

            return user;
        }
        // Method to search for a user by UserId
        public static UserAccount SearchRecord(int userId)
        {
            SqlConnection connectDB = UtilityDB.ConnectDB();
            UserAccount user = new UserAccount();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM UserAccounts WHERE UserId = @UserId", connectDB);
            cmdSearch.Parameters.AddWithValue(@"UserId", userId);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                user.EmployeeId = Convert.ToInt32(sqlRead["EmployeeId"]);
                user.Password = sqlRead["Password"].ToString();
                user.UserId = Convert.ToInt32(sqlRead["UserId"]);
            }
            else
            {
                user = null;
            }

            return user;
        }
        // Method to search for a user by EmployeeId 
        public static UserAccount SearchRecordByEmpId(int empId)
        {
            SqlConnection connectDB = UtilityDB.ConnectDB();
            UserAccount user = new UserAccount();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM UserAccounts WHERE EmployeeId = @EmployeeId", connectDB);
            cmdSearch.Parameters.AddWithValue(@"EmployeeId", empId);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                user.EmployeeId = Convert.ToInt32(sqlRead["EmployeeId"]);
                user.Password = sqlRead["Password"].ToString();
                user.UserId = Convert.ToInt32(sqlRead["UserId"]);
            }
            else
            {
                user = null;
            }

            return user;
        }
        // Method to add a user
        public static void SaveRecord(UserAccount user)
        {
            // Step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Insert operation
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO UserAccounts (UserId,Password,EmployeeId) VALUES(@UserId,@Password,@EmployeeId);", connDB);
            cmdInsert.Parameters.AddWithValue("@EmployeeId", user.EmployeeId);
            cmdInsert.Parameters.AddWithValue("@Password", user.Password);
            cmdInsert.Parameters.AddWithValue("@UserId", user.UserId);
            cmdInsert.ExecuteNonQuery();
            // Step 3: Close the DB
            connDB.Close();
        }
        // Method to update user information
        public static void UpdateRecord(UserAccount user)
        {
            //step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //step 2: Perform Update operation 
            SqlCommand cmdUpdate = new SqlCommand("UPDATE UserAccounts SET Password = @Password, EmployeeId = @EmployeeId WHERE UserId = @UserId", connDB);
            cmdUpdate.Parameters.AddWithValue("@EmployeeId", user.EmployeeId);
            cmdUpdate.Parameters.AddWithValue("@Password", user.Password);
            cmdUpdate.Parameters.AddWithValue("@UserId", user.UserId);
            cmdUpdate.ExecuteNonQuery();
            //step 3: Close DB
            connDB.Close();
        }
        // Method to delete an user
        public static void DeleteRecord(int userId)
        {
            //step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //step 2: Perform Delete operation 
            SqlCommand cmdDelete = new SqlCommand("DELETE FROM UserAccounts WHERE UserId = @UserId", connDB);
            cmdDelete.Parameters.AddWithValue("@UserId", userId);
            cmdDelete.ExecuteNonQuery();
            //step 3: Close DB
            connDB.Close();
        }
        // Method to list all users
        public static List<UserAccount> GetRecordList()
        {
            List<UserAccount> listUser = new List<UserAccount>();
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Select all operation
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM UserAccounts", connDB);
            SqlDataReader sqlReader = cmdSelectAll.ExecuteReader();
            UserAccount user;
            while (sqlReader.Read())
            {
                user = new UserAccount();
                user.UserId = Convert.ToInt32(sqlReader["UserId"]);
                user.EmployeeId = Convert.ToInt32(sqlReader["EmployeeId"]);
                user.Password = sqlReader["Password"].ToString();
                listUser.Add(user);

            }
            // Step 3: Close the database 
            connDB.Close();
            return listUser;
        }

    }
}
