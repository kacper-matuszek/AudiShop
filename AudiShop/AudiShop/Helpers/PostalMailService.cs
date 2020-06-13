using AudiShop.ViewModels;
using AudiShop.Data.Models;

namespace AudiShop.Helpers
{
    public class PostalMailService : IMailService
    {
        public void SendMailOfOrderConfirmation(Order order)
        {
            OrderConfirmationEmail email = new OrderConfirmationEmail()
            {
                To = order.Email,
                From = "AudiShop@gmail.com",
                OrderValue = order.Value,
                OrderNumber = order.OrderID,
                OrderDetails = order.OrderDetails
            };

            email.Send();
        }
    }
}