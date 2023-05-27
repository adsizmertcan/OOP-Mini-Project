using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    public class CategoryCustomer : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
