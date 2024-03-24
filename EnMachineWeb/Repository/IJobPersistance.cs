using EnMachineWeb.Models;
using System.Collections.Generic;

namespace EnMachineWeb.Repositories
{
    public interface IJobPersistance
    {
        List<GetJobList> GetJobDetailList();
    }
}