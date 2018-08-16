using Microsoft.AspNetCore.Mvc;
using NationalCookies.Data.Interfaces;

namespace NationalCookies.Controllers
{
    public class CookieController : Controller
    {
        private ICookieService _cookieService;

        public CookieController(ICookieService cookieService)
        {    
            _cookieService = cookieService;          
        }

        public IActionResult Index()
        {
            return View(_cookieService.GetAllCookies());
        }
    }
}
