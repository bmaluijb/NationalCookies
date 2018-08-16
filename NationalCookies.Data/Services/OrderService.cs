using NationalCookies.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;


namespace NationalCookies.Data.Services
{
    public class OrderService : IOrderService
    {

        private CookieContext _context;

        public OrderService(CookieContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds cookies to orders
        /// </summary>
        /// <param name="cookieId"></param>
        public void AddCookieToOrder(int cookieId)
        {
            //get the oder with the status new (if any)
            Order currentOrder = _context.Orders
                                      .Where(o => o.Status == "New")
                                      .Include(o => o.OrderLines)
                                        .ThenInclude(OrderLine => OrderLine.Cookie)
                                      .FirstOrDefault();

            //if there is a order with status new
            if (currentOrder != null)
            {
                //loop through the lines of the order
                //and check if the cookie that we want to add is
                //already in there
                bool orderLineExists = false;
                foreach (var lines in currentOrder.OrderLines)
                {
                    if (lines.Cookie.Id == cookieId)
                    {
                        lines.Quantity++;
                        orderLineExists = true;

                        currentOrder.Price += lines.Cookie.Price;
                    }
                }

                //if the cookie is new in this order
                if (!orderLineExists)
                {
                    //get the cookie
                    var cookie = _context.Cookies.Where(c => c.Id == cookieId).FirstOrDefault();

                    //add it to a new orderline
                    currentOrder.OrderLines.Add(new OrderLine
                    {
                        Cookie = cookie,
                        Quantity = 1
                    });

                    currentOrder.Price += cookie.Price;
                }

                _context.Update(currentOrder);
                _context.SaveChanges();
            }
            else
            {
                //if there is no order with status new
                //create one
                currentOrder = new Order();
                currentOrder.Date = DateTimeOffset.Now;
                currentOrder.Status = "New";

                var cookie = _context.Cookies.Where(c => c.Id == cookieId).FirstOrDefault();

                currentOrder.OrderLines.Add(new OrderLine
                {
                    Cookie = cookie,
                    Quantity = 1
                });

                currentOrder.Price += cookie.Price;

                _context.Add(currentOrder);
                _context.SaveChanges();
            }


        }

        /// <summary>
        /// gets all orders
        /// </summary>
        /// <returns></returns>
        public List<Order> GetAllOrders()
        {
            //get orders from the database
            var orders = _context.Orders
                            .Include(o => o.OrderLines)
                            .ToList();

            //sort the orders by date
            orders = orders.OrderBy(o => o.Date).ToList();

            return orders;
        }

        /// <summary>
        /// gets a specific order by id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order GetOrderById(int orderId)
        {
            //get the order by id
            Order order = _context.Orders
                        .Include(o => o.OrderLines)
                            .ThenInclude(OrderLine => OrderLine.Cookie)
                        .Where(o => o.Id == orderId).FirstOrDefault();

            return order;
        }



        /// <summary>
        /// deletes an order
        /// </summary>
        /// <param name="orderId"></param>
        public void CancelOrder(int orderId)
        {
            //the order is in the database, remove it
            var order = _context.Orders.Where(o => o.Id == orderId).FirstOrDefault();
            if (order != null)
            {
                _context.Remove(order);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// places an order by chaning it status to "Placed"
        /// </summary>
        /// <param name="orderId"></param>
        public void PlaceOrder(int orderId)
        {
            //get the order
            var order = _context.Orders.Where(o => o.Id == orderId).FirstOrDefault();
            if (order != null)
            {
                //change its status
                order.Status = "Placed";

                //save it
                _context.Update(order);
                _context.SaveChanges();
            }
        }
    }

}
