using AudiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudiShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<ModelType> Models { get; set; }

    }
}