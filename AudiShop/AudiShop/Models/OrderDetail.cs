using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudiShop.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ModelID { get; set; }
        public int Amount { get; set; }
        public decimal PriceValue { get; set; }

        public virtual Model Models { get; set; }
        public virtual Order Orders { get; set; }
    }
}