using Postal;
using System.Collections.Generic;
using AudiShop.Data.Models;

namespace AudiShop.ViewModels
{
    public class OrderConfirmationEmail : Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public decimal OrderValue { get; set; }
        public int OrderNumber { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}