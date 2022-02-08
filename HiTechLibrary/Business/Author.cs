using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechLibrary.DataAccess;

namespace HiTechLibrary.Business
{
    public class Author
    {
        private int authorId;
        private string firstName;
        private string lastName;
        private string email;

        public int AuthorId { get => authorId; set => authorId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }

        public Author SearchAuthor(int auId)
        {
            return AuthorDB.GetRecord(auId);
        }

        public void SaveAuthor(Author au)
        {
            AuthorDB.SaveRecord(au);
        }

        public void DeleteAuthor(int auId)
        {
            AuthorDB.DeleteRecord(auId);
        }

        public void UpdateAuthor(Author au)
        {
            AuthorDB.UpdateRecord(au);
        }
    }
}
