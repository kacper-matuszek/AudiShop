using System.Web;
using System.Web.Mvc;
using AudiShop.Data.Models;
using Hangfire;

namespace AudiShop.Helpers
{
    public class HangfirePostalMailService : IMailService
    {
        public void SendMailOfOrderConfirmation(Order order)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendMailOfOrderConfirmation", "Manage", new { orderID = order.OrderID, lastName = order.LastName }, HttpContext.Current.Request.Url.Scheme);
            BackgroundJob.Enqueue(() => UrlHelpers.CallUrl(url));
        }
    }
}