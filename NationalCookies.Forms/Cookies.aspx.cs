using Microsoft.EntityFrameworkCore;
using NationalCookies.Data;
using NationalCookies.Data.Services;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace NationalCookies.Forms
{
    public partial class Cookies : System.Web.UI.Page
    {
        private CookieService _cookieService;
        private OrderService _orderService;
        public List<Cookie> Model { get; set; }


        public Cookies()
        {
            //instantiate services
            var optionsBuilder =
                new DbContextOptionsBuilder()
                    .UseSqlServer(ConfigurationManager.ConnectionStrings["CookieDBConnection"].ConnectionString);

            var context = new CookieContext(optionsBuilder.Options);

            _cookieService = new CookieService(context);
            _orderService = new OrderService(context);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllCookies();

            //check for querystrings
            if (Request.QueryString.Count > 0)
            {
                //try and get the cookieid
                int cookieId = -1;
                if (int.TryParse(Request.QueryString["CookieId"], out cookieId))
                {
                    //add the cookie to the order
                    _orderService.AddCookieToOrder(cookieId);
                    Response.Redirect("Orders.aspx");
                }
            }
        }

        public void GetAllCookies()
        {
            //check if the cookies are in the session
            if(Session["Cookies"] == null)
            {
                //get all of the cookies
                Model = _cookieService.GetAllCookies();

                //put them in the cache
                Session["Cookies"] = Model;
            }
            else //if they are, get them from session
            {
                Model = (List<Cookie>)Session["Cookies"];
            }
        }
    }
}