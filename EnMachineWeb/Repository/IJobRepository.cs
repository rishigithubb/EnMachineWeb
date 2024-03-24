using EnMachineWeb.Models;
using System.Collections.Generic;

namespace EnMachineWeb.Controllers
{
    public interface IJobRepository
    {
        List<GetJobList> GetJobDetailList();
        object GetJobList();
    }
}