using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechLibrary.DataAccess;

namespace HiTechLibrary.Business
{
    public class OrderLine
    {
        private int orderId;
        private string iSBN;
        private int quantityOrdered;

        public int OrderId { get => orderId; set => orderId = value; }
        public int QuantityOrdered { get => quantityOrdered; set => quantityOrdered = value; }
        public string ISBN { get => iSBN; set => iSBN = value; }
        
        public OrderLine SearchOrderLine(int ordId, string iSBN)
        {
            return OrderLineDB.GetRecord(ordId, iSBN);
        }
        public List<OrderLine> SearchListOrderLine(string iSBN)
        {
            return OrderLineDB.GetRecord(iSBN);
        }
    }
}
