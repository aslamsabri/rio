using Microsoft.AspNetCore.Mvc;

namespace Ria.CustomerAPI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
