using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HiTechLibrary.Business;

namespace HiTechLibrary.DataAccess
{
    public static class EmployeeDB
    {
        // Method to add an employee
        public static void SaveRecord(Employee emp)
        {
            // Step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Insert operation
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Employees(EmployeeId,FirstName,LastName,PhoneNumber,Email,JobId) VALUES(@EmployeeId,@FirstName,@LastName,@PhoneNumber,@Email,@JobId);", connDB);
            cmdInsert.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmdInsert.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdInsert.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber);
            cmdInsert.Parameters.AddWithValue("@Email", emp.Email);
            cmdInsert.Parameters.AddWithValue("@JobId", emp.JobId);
            cmdInsert.ExecuteNonQuery();
            // Step 3: Close the DB
            connDB.Close();
        }
        // Method to update employee information
        public static void UpdateRecord(Employee emp)
        {
            //step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //step 2: Perform Update operation 
            SqlCommand cmdUpdate = new SqlCommand("UPDATE Employees SET FirstName = @FirstName, LastName = @LastName,PhoneNumber = @PhoneNumber, Email = @Email, JobId = @JobId WHERE EmployeeId = @EmployeeId", connDB);
            cmdUpdate.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmdUpdate.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdUpdate.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdUpdate.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber);
            cmdUpdate.Parameters.AddWithValue("@Email", emp.Email);
            cmdUpdate.Parameters.AddWithValue("@JobId", emp.JobId);
            cmdUpdate.ExecuteNonQuery();
            //step 3: Close DB
            connDB.Close();
        }
        // Method to delete an employee
        public static void DeleteRecord(int empId)
        {
            //step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //step 2: Perform Delete operation 
            SqlCommand cmdDelete = new SqlCommand("DELETE FROM Employees WHERE EmployeeId = @EmployeeId", connDB);
            cmdDelete.Parameters.AddWithValue("@EmployeeId", empId);
            cmdDelete.ExecuteNonQuery();
            //step 3: Close DB
            connDB.Close();
        }
        // Method to search for an employee by Id
        public static Employee GetRecord(int empId)
        {
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            //Step 2: Perform Search operation
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Employees WHERE EmployeeId = @empId", connDB);
            cmdSelect.Parameters.AddWithValue("@empId", empId);
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Employee emp = new Employee();
            if (sqlReader.Read())
            {
                emp.EmployeeId = Convert.ToInt32(sqlReader["EmployeeId"]);
                emp.FirstName = sqlReader["FirstName"].ToString();
                emp.LastName = sqlReader["LastName"].ToString();
                emp.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                emp.Email = sqlReader["Email"].ToString();
                emp.JobId = Convert.ToInt32(sqlReader["JobId"]);
            }
            else
            {
                emp = null;

            }
            // Step 3: Close the database
            connDB.Close();
            return emp;
        }
        // Method to list all employees
        public static List<Employee> GetRecordList()
        {
            List<Employee> listEmp = new List<Employee>();
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Select all operation
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", connDB);
            SqlDataReader sqlReader = cmdSelectAll.ExecuteReader();
            Employee emp;
            while (sqlReader.Read())
            {
                emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(sqlReader["EmployeeId"]);
                emp.FirstName = sqlReader["FirstName"].ToString();
                emp.LastName = sqlReader["LastName"].ToString();
                emp.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                emp.Email = sqlReader["Email"].ToString();
                emp.JobId = Convert.ToInt32(sqlReader["JobId"]);
                listEmp.Add(emp);

            }
            // Step 3: Close the database 
            connDB.Close();
            return listEmp;
        }
        // Method to list employees by first name or last name
        public static List<Employee> GetRecordListbyName(string empName, string select)
        {
            List<Employee> listEmp = new List<Employee>();
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Select all operation
            SqlCommand cmdSelectName = new SqlCommand("SELECT * FROM Employees " + "WHERE " + select + " = @Name ", connDB);
            cmdSelectName.Parameters.AddWithValue("@Name", empName);
            SqlDataReader sqlReader = cmdSelectName.ExecuteReader();
            Employee emp;
            while (sqlReader.Read())
            {
                emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(sqlReader["EmployeeId"]);
                emp.FirstName = sqlReader["FirstName"].ToString();
                emp.LastName = sqlReader["LastName"].ToString();
                emp.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                emp.Email = sqlReader["Email"].ToString();
                emp.JobId = Convert.ToInt32(sqlReader["JobId"]);
                listEmp.Add(emp);

            }
            // Step 3: Close the Database
            connDB.Close();
            return listEmp;
        }
    }
}
