using System;
using EnMachineWeb.Models;

namespace EnMachineWeb.Models
{
    public class GetJobList
    {
        public long JobId { get; set; }
        public string JobTitle { get; set; }
        public string AssignEngineerName { get; set; }
        public string PhoneNumber { get; set; }
        public string JobStatus { get; set; }
        public DateTime JobCreated { get; set; }
    }
}