using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechLibrary.DataAccess;

namespace HiTechLibrary.Business
{
    public class Book
    {
        private string iSBN;
        private string bookTitle;
        private decimal unitPrice;
        private int qOH;
        private int publisherId;
        private int categoryId;
        private int status;

        public string BookTitle { get => bookTitle; set => bookTitle = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public string ISBN { get => iSBN; set => iSBN = value; }
        public int QOH { get => qOH; set => qOH = value; }
        public int PublisherId { get => publisherId; set => publisherId = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public int Status { get => status; set => status = value; }

        public List<Book> SearchAllBook()
        {
            return BookDB.GetRecord();
        }

        public void SaveBook(Book book)
        {
            BookDB.SaveRecord(book);
        }

        public void UpdateBook(Book book)
        {
            BookDB.UpdateRecord(book);
        }

        public void DeleteBook(string iSBN)
        {
            BookDB.DeleteRecord(iSBN);
        }

        public Book SearchBook(string iSBN)
        {
            return BookDB.GetRecord(iSBN);
        }

        public List<Book> SearchBookByTitle(string title)
        {
            return BookDB.GetRecordByTitle(title);
        }

        public List<Book> SearchBook(int id, string select)
        {
            return BookDB.GetRecord(id, select);
        }
    }
}
