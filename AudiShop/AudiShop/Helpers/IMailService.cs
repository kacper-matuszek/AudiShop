using AudiShop.Models;

namespace AudiShop.Helpers
{
    public interface IMailService
    {
        void SendMailOfOrderConfirmation(Order order);
    }
}