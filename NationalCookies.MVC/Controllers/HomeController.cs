
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NationalCookies.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Error()
        {          
            return View();
        }


    }
}
