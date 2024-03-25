using System;
using System.Collections.Generic;
using System.Net.Http;
using EnMachineWeb.Controllers;
using EnMachineWeb.Models;
using Dapper;
using Newtonsoft.Json;

namespace EnMachineWeb.Repositories
{
    public class JobRepository : IJobRepository
    {
        Uri baseAddress = new Uri("http://localhost:59160/");
        private readonly HttpClient _httpClient;
        public JobRepository()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public List<GetJobList> GetJobDetailList()
        {
            List<GetJobList> jobLists = new List<GetJobList>();

            HttpResponseMessage reponse = _httpClient.GetAsync(_httpClient.BaseAddress+ "/api/GetJobList").Result;

            if(reponse.IsSuccessStatusCode)
            {
                string data = reponse.Content.ReadAsStringAsync().Result;
                jobLists = JsonConvert.DeserializeObject<List<GetJobList>>(data); 
            }

            return jobLists;
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:59160/"); // Adjust the base URL as needed
            //    var response = client.GetAsync("api/GetJobList").Result;

            //    if (response.IsSuccessStatusCode)
            //    {
            //        jobLists = response.Content.ReadAsAsync<List<GetJobList>>().Result;
            //    }

            //    return jobLists;
            //}
        }

        public object GetJobList()
        {
            throw new NotImplementedException();
        }
    }
}
