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
    public partial class Orders : System.Web.UI.Page
    {
        private OrderService _orderService;
        public List<Order> Model { get; set; }
        
        public Orders()
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
            //check for querystrings in the response
            if (Request.QueryString.Count > 0)
            {
                //try to get th order id from the querystring
                int orderId = -1;
                if (int.TryParse(Request.QueryString["id"], out orderId))
                {
                    //get the action and act on that
                    switch (Request.QueryString["action"])
                    {
                        case "CancelOrder":
                            _orderService.CancelOrder(orderId);
                            break;
                        case "PlaceOrder":
                            _orderService.PlaceOrder(orderId);
                            break;
                        default:
                            break;
                    }                    
                }
            }

            //fill the model with orders
            Model = _orderService.GetAllOrders();
        }
    }
}