using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechLibrary.DataAccess;

namespace HiTechLibrary.Business
{
    public class AuthorBook
    {
        private string iSBN;
        private int authorId;
        private string yearPublished;
        private string edition;

        public string ISBN { get => iSBN; set => iSBN = value; }
        public int AuthorId { get => authorId; set => authorId = value; }
        public string YearPublished { get => yearPublished; set => yearPublished = value; }
        public string Edition { get => edition; set => edition = value; }

        public AuthorBook SearchAuthorBook(int auId, string iSBN)
        {
            return AuthorBookDB.GetRecord(auId, iSBN);
        }
        public List<AuthorBook> SearchListAuthorBook(string iSBN)
        {
            return AuthorBookDB.GetListRecord(iSBN);
        }
        public List<AuthorBook> SearchListAuthorBook(int authorId)
        {
            return AuthorBookDB.GetListRecord(authorId);
        }
        public void SaveAuthorBook(AuthorBook auBo)
        {
            AuthorBookDB.SaveRecord(auBo);
        }
        public void UpdateAuthorBook(AuthorBook auBo)
        {
            AuthorBookDB.UpdateRecord(auBo);
        }
        public void DeleteAuthorBook(int authorId, string iSBN)
        {
            AuthorBookDB.DeleteRecord(authorId, iSBN);
        }
    }
}
