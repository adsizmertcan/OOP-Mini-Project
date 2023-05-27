using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    public class JobController : Controller
    {
        JobManager jobManager = new JobManager(new EfJobDal ());
        public IActionResult Index()
        {
            var values = jobManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job P)
        {
            JobValidator validationRules = new JobValidator();
            ValidationResult results = validationRules.Validate(P);
            if (results.IsValid)
            {
                jobManager.TAdd(P);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteJob(int id)
        {
            var values = jobManager.TGetById(id);
            jobManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            var values = jobManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateJob(Job job)
        {
            jobManager.TUpdate(job);
            return RedirectToAction("Index");
        }

    }
}
