using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudiShop.Models
{
    public class Silnik
    {
        public int SilnikID { get; set; }

        public float Pojemnosc { get; set; }
        public int KonieMechaniczne { get; set; }
        public int KiloWaty { get; set; }
        public TypSilnika Typ { get; set; }
        public string Oznaczenie { get; set; }
        public bool Turbo { get; set; }

        public virtual ICollection<Model> Modele { get; set; }
    }

    public enum TypSilnika
    {
        Diesel,
        Benzyna,
        Elektryczny
    }
}