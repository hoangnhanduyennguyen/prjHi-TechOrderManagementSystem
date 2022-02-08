using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechLibrary.DataAccess;

namespace HiTechLibrary.Business
{
    public class Category
    {
        private int categoryId;
        private string categoryName;

        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }

        public Category SearchCategory(int catId)
        {
            return CategoryDB.SearchRecord(catId);
        }

        public List<Category> SearchAllCategory()
        {
            return CategoryDB.GetRecordList();
        }
    }
}
