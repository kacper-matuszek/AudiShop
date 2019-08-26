using AudiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudiShop.ViewModels
{
    public class EditModelViewModel
    {
        public Model Model{ get; set; }
        public IEnumerable<Categoria> Categories { get; set; }
        public IEnumerable<Engine> Engines { get; set; }
        public bool? Confirmation { get; set; }
    }
}