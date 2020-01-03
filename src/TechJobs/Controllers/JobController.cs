using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;
using TechJobs.Models;


namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            Job jerb = JobData.GetInstance().Find(id);
            // TODO #1 - get the Job with the given ID and pass it into the view
            return View(jerb);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            Job jerb = new Job
            {
                Name = newJobViewModel.Name,
                Employer = jobData.Employers.Find(newJobViewModel.EmployerID),
                // I need to create a new job object but the properties also need to be objects
                // IDK how to find the other object properties
                //Location = jobData.Locations.Find(newJobViewModel.Location),
                //CoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.)

        };

            jobData.Jobs.Add(jerb);

            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.

            // Don't I want to also redirect????
            return View(newJobViewModel);
        }
    }
}
