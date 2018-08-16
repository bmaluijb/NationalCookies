using NationalCookies.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NationalCookies.Data.Services
{
    public class CookieService : ICookieService
    {
        private CookieContext _context;

        public CookieService(CookieContext context)
        {
            _context = context;
        }

        public List<Cookie> GetAllCookies()
        {
            List<Cookie> cookies;

            //get the cookies from the database
            cookies = _context.Cookies.ToList();

            return cookies;
        }
    }
}
