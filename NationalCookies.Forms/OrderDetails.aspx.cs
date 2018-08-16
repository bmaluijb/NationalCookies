using Microsoft.EntityFrameworkCore;
using NationalCookies.Data;
using NationalCookies.Data.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NationalCookies.Forms
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        private OrderService _orderService;
        public Order Model { get; set; }


        public OrderDetails()
        {
            //instantiate services
            var optionsBuilder =
                new DbContextOptionsBuilder()
                .UseSqlServer(ConfigurationManager.ConnectionStrings["CookieDBConnection"].ConnectionString);

            var context = new CookieContext(optionsBuilder.Options);
            _orderService = new OrderService(context);

        }

        protected void Page_Load(object sender, EventArgs e)
        {            
            //check for querystrings
            if (Request.QueryString.Count > 0)
            {
                //try and get the order id
                int orderId = -1;
                if (int.TryParse(Request.QueryString["id"], out orderId))
                {
                    //load the order into the model
                    Model = _orderService.GetOrderById(orderId);
                }
            }
        }
    }
}