using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using EnMachineWeb.Repositories;

namespace EnMachineWeb.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobRepository _jobRepository;

        public JobController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public ActionResult Index()
        {
            try
            {
                var jobLists = _jobRepository.GetJobList();
                return View(jobLists);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
    }
}
