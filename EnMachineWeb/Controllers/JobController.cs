using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using EnMachineWeb.Repositories;

namespace EnMachineWeb.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobRepository _jobRepository;

        public JobController()
        {
            _jobRepository = new JobRepository();
        }

        public ActionResult GetJobList()
        {
            try
            {
                var jobLists = _jobRepository.GetJobDetailList();
                return View(jobLists);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
        public ActionResult CreateJob()
        {
            return View();
        }
    }
}
