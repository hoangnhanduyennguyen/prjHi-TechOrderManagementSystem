using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HiTechLibrary.Business;

namespace HiTechLibrary.DataAccess
{
    public static class CustomerDB
    {
        // Method to search for a customer by CustomerId
        public static Customer GetRecord(int custId)
        {
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            //Step 2: Perform Search operation
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Customers WHERE CustomerId = @custId", connDB);
            cmdSelect.Parameters.AddWithValue("@custId", custId);
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Customer cust = new Customer();
            if (!sqlReader.Read())
            {
                cust = null;
            }
            // Step 3: Close the database
            connDB.Close();
            return cust;
        }
        // Method to list all customers
        public static List<Customer> GetRecordList()
        {
            List<Customer> listCust = new List<Customer>();
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Select all operation
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Customers", connDB);
            SqlDataReader sqlReader = cmdSelectAll.ExecuteReader();
            Customer cust;
            while (sqlReader.Read())
            {
                cust = new Customer();
                cust.CustomerId = Convert.ToInt32(sqlReader["CustomerId"]);
                cust.CustomerName = sqlReader["CustomerName"].ToString();
                cust.StreetName = sqlReader["StreetName"].ToString();
                cust.Province = sqlReader["Province"].ToString();
                cust.City = sqlReader["City"].ToString();
                cust.PostalCode = sqlReader["PostalCode"].ToString();
                cust.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                cust.ContactName = sqlReader["ContactName"].ToString();
                cust.ContactEmail = sqlReader["ContactEmail"].ToString();
                cust.CreditLimit = Convert.ToInt32(sqlReader["CreditLimit"]);
                cust.Status = Convert.ToInt32(sqlReader["Status"]);
                listCust.Add(cust);
            }
            // Step 3: Close the database 
            connDB.Close();
            return listCust;
        }
    }
}
