using System;
using System.Collections.Generic;
using System.Net.Http;
using EnMachineWeb.Controllers;
using EnMachineWeb.Models;
using Dapper;

namespace EnMachineWeb.Repositories
{
    public class ApiJobRepository : IJobRepository
    {
        public List<JobList> JobDetailList
        {
            get
            {
                List<JobList> jobLists = new List<JobList>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:59160/"); // Adjust the base URL as needed
                    var response = client.GetAsync("api/GetJobList").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        jobLists = response.Content.ReadAsAsync<List<JobList>>().Result;
                    }

                    return jobLists;
                }
            }
        }

        public List<GetJobList> GetJobDetailList()
        {
            throw new NotImplementedException();
        }

        public object GetJobList()
        {
            throw new NotImplementedException();
        }
    }
}
