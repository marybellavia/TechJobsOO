using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;
using TechJobs.Models;
using System.Linq;


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

            Employer newEmployer = jobData.Employers.Find(newJobViewModel.EmployerID);
            Location foundLocation = jobData.Locations.ToList(newJobViewModel.Location);
            CoreCompetency foundCoreCompetency = ;
            PositionType foundPositionType = ;

            Job jerb = new Job
            {
                Name = newJobViewModel.Name,
                Employer = newEmployer,
                Location = jobData.Locations.Find(newJobViewModel.Location),
                // I need to create a new job object but the properties also need to be objects
                // IDK how to find the other object properties
                //Location = jobData.Locations.Find(newJobViewModel.Location),
                //CoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.)

        };

            jobData.Jobs.Add(jerb);

            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.


            // need to redirect
            return View(newJobViewModel);
        }
    }
}
