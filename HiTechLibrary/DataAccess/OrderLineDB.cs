using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HiTechLibrary.Business;

namespace HiTechLibrary.DataAccess
{
    public static class OrderLineDB
    {
        // Method to search for an orderline by order id and ISBN
        public static OrderLine GetRecord(int ordId, string iSBN)
        {
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            //Step 2: Perform Search operation
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM OrderLines WHERE OrderId = @ordId AND ISBN = @iSBN", connDB);
            cmdSelect.Parameters.AddWithValue("@auId", ordId);
            cmdSelect.Parameters.AddWithValue("@iSBN", iSBN);
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            OrderLine oL = new OrderLine();
            if (sqlReader.Read())
            {
                oL.OrderId = Convert.ToInt32(sqlReader["OrderId"]);
                oL.ISBN = sqlReader["ISBN"].ToString();
                oL.QuantityOrdered = Convert.ToInt32(sqlReader["QuantityOrdered"]);
            }
            else
            {
                oL = null;

            }
            // Step 3: Close the database
            connDB.Close();
            return oL;
        }
        // Method to search for orderline by ISBN
        public static List<OrderLine> GetRecord(string iSBN)
        {
            List<OrderLine> listOrderLine = new List<OrderLine>();
            OrderLine orderLine;
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM OrderLines WHERE ISBN = @iSBN", conn);
            cmdSearch.Parameters.AddWithValue("@iSBN", iSBN);
            SqlDataReader sqlReader = cmdSearch.ExecuteReader();
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    orderLine = new OrderLine();
                    orderLine.ISBN = sqlReader["ISBN"].ToString();
                    orderLine.OrderId = Convert.ToInt32(sqlReader["OrderId"]);
                    listOrderLine.Add(orderLine);
                }
            }
            else
            {
                listOrderLine = null;
            }
            return listOrderLine;
        }

    }
}
