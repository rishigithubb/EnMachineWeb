 using System; 
using System.Collections.Generic;
using System.Net.Http;
using EnMachineWeb.Controllers;
using EnMachineWeb.Models;
using Dapper;
using Newtonsoft.Json;
using System.Configuration;

namespace EnMachineWeb.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly HttpClient _httpClient;
        public JobRepository()
        {
            _httpClient = new HttpClient();
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"]; // Read base URL from appSettings
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public Uri ApiBaseUrl { get; }

        public List<GetJobList> GetJobDetailList()
        {
            List<GetJobList> jobLists = new List<GetJobList>();

            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress+ "/api/GetJobList").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                jobLists = JsonConvert.DeserializeObject<List<GetJobList>>(data);
            }
            else
            {
                // Handle bad request or other errors
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    // Handle bad request error
                    throw new HttpRequestException("Bad request: " + response.ReasonPhrase);
                }
                else
                {
                    // Handle other errors
                    throw new HttpRequestException("Error: " + response.StatusCode + " - " + response.ReasonPhrase);
                }
            }

            return jobLists;
        }

        public object GetJobList()
        {
            throw new NotImplementedException();
        }
    }
    }


