using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HiTechLibrary.Business;

namespace HiTechLibrary.DataAccess
{
    public static class JobDB
    {
        //Method to search for a job by job id
        public static Job GetRecord(int jobId)
        {
            SqlConnection connectDB = UtilityDB.ConnectDB();
            Job job = new Job();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM Jobs WHERE JobId = @JobId", connectDB);
            cmdSearch.Parameters.AddWithValue("@JobId", jobId);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                job.JobId = Convert.ToInt32(sqlRead["JobId"]);
                job.JobTitle = sqlRead["JobTitle"].ToString();
            }
            else
            {
                job = null;
            }

            return job;
        }
        //Method to list all jobs
        public static List<Job> GetRecordList()
        {
            List<Job> listJob = new List<Job>();
            // Step 1: Connect the Database
            SqlConnection connDB = UtilityDB.ConnectDB();
            // Step 2: Perform Select all operation
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Jobs", connDB);
            SqlDataReader sqlReader = cmdSelectAll.ExecuteReader();
            Job job;
            while (sqlReader.Read())
            {
                job = new Job();
                job.JobId = Convert.ToInt32(sqlReader["JobId"]);
                job.JobTitle = sqlReader["JobTitle"].ToString();
                listJob.Add(job);

            }
            // Step 3: Close the database 
            connDB.Close();
            return listJob;
        }
    }
}
