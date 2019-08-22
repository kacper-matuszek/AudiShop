using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudiShop.ViewModels
{
    public class TrolleyRemovingViewModel
    {
        public decimal TrolleyTotalPrice { get; set; }
        public int CountPositionsOfTrolley { get; set; }
        public int CountToRemove { get; set; }
        public int IdPositionRemoving { get; set; }
    }
}