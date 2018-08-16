using System.Collections.Generic;

namespace NationalCookies.Data.Interfaces
{
    public interface IOrderService
    {
        void AddCookieToOrder(int cookieId);

        List<Order> GetAllOrders();

        Order GetOrderById(int orderId);

        void CancelOrder(int orderId);

        void PlaceOrder(int orderId);

    }
}
