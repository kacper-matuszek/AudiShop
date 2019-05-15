using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudiShop.Models
{
    //Typ nadwozia
    public class Kategoria
    {
        public int KategoriaID { get; set; }

        public string Nazwa { get; set; }
        public string NazwaObrazka { get; set; }

        public virtual ICollection<Model> Modele { get; set; }
    }
}