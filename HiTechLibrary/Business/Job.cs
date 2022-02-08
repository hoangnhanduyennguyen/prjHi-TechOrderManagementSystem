using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechLibrary.DataAccess;

namespace HiTechLibrary.Business
{
    public class Job
    {
        private int jobId;
        private string jobTitle;

        public int JobId { get => jobId; set => jobId = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }

        public Job SearchJob(int jobId)
        {
            return JobDB.GetRecord(jobId);
        }

        public List<Job> SearchJobList()
        {
            return JobDB.GetRecordList();
        }
    }
}
