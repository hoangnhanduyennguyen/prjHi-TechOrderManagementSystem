using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechLibrary.DataAccess;

namespace HiTechLibrary.Business
{
    public class Status
    {
        private int id;
        private string description;

        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
    
        public List<Status> SearchStatus(string select)
        {
            return StatusDB.GetRecordList(select);
        }
    }
}
