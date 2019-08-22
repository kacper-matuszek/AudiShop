using AudiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudiShop.ViewModels
{
    public class TrolleyViewModel
    {
        public List<PositionTrolley> PositionsTrolley { get; set; }
        public decimal TotalPrice { get; set; }
    }
}