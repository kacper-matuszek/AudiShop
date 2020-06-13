using System.Collections.Generic;
using AudiShop.Data.Models;

namespace AudiShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<ModelType> Models { get; set; }

    }
}