using Microsoft.Extensions.Caching.Distributed;
using NationalCookies.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace NationalCookies.Data.Services
{
    public class CookieService : ICookieService
    {
        private CookieContext _context;
        private IDistributedCache _cache;

        public CookieService(CookieContext context, IDistributedCache cache = null)
        {
            _context = context;
            _cache = cache;
        }

        public List<Cookie> GetAllCookies()
        {
            List<Cookie> cookies;
            
            //if njo cache is passed into the constructir
            //of this service, just get the cookies from the database and return them
            if(_cache == null)
            {
                return cookies = _context.Cookies.ToList();                
            }

            //first, try to get cookies from cache
            var cachedCookies = _cache.GetString("cookies");
            if (!string.IsNullOrEmpty(cachedCookies)){

                //if they are there, deserialize them
                cookies = JsonConvert.DeserializeObject<List<Cookie>>(cachedCookies);
            }
            else
            {
                //if no cookies in are in cache yet, get them from the database
                cookies = _context.Cookies.ToList();

                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
                options.SetAbsoluteExpiration(new System.TimeSpan(0, 0, 15));

                //and then, put them in cache
                _cache.SetString("cookies", JsonConvert.SerializeObject(cookies), options);
            }

            return cookies;
        }

        public void ClearCache()
        {
            _cache.Remove("cookies");
        }
    }
}
