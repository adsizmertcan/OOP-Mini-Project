using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoProject.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        JobManager jobManager = new JobManager(new EfJobDal());
        public IActionResult Index()
        {
            var values = customerManager.GetCustomerListWithJob();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {

            List<SelectListItem> values = (from X in jobManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = X.JobName,
                                               Value = X.JobId.ToString()
                                           }).ToList();
            ViewBag.V = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult results = validationRules.Validate(customer);
            if (results.IsValid)
            {
                customerManager.TAdd(customer);
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
         public IActionResult DeleteCustomer(int id) 
        {
            var values = customerManager.TGetById(id);
            customerManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            List<SelectListItem> value = (from X in jobManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = X.JobName,
                                               Value = X.JobId.ToString()
                                           }).ToList();
            ViewBag.V = value;
            var values = customerManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer P)
        {
            customerManager.TUpdate(P);
            return RedirectToAction("Index");
        }
    }
}
