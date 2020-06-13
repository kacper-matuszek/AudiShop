using System.Collections.Generic;
using AudiShop.Data.Models;

namespace AudiShop.ViewModels
{
    public class TrolleyViewModel
    {
        public List<PositionTrolley> PositionsTrolley { get; set; }
        public decimal TotalPrice { get; set; }
    }
}