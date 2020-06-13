using System.Collections.Generic;
using AudiShop.Data.Models;

namespace AudiShop.ViewModels
{
    public class EditModelViewModel
    {
        public Model Model{ get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Engine> Engines { get; set; }
        public bool? Confirmation { get; set; }
    }
}