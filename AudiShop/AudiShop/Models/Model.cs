using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AudiShop.Models
{
    public class Model
    {
        public int ModelID { get; set; }
        public int KategoriaID { get; set; }
        public int SilnikID { get; set; }

        [Required(ErrorMessage = "Wprowadz nazwe modelu")]
        [StringLength(100, ErrorMessage ="Nazwa nie może mieć więcej niż 100 znaków.")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Wprowadz opis modelu.")]
        public string Opis { get; set; }
        public string Kolor { get; set; }
        public string NazwaObrazka { get; set; }

        public decimal Cena { get; set; }
        public bool Aktualny { get; set; }

        //Kategoria == Podwozie
        public virtual Kategoria Kategoria { get; set; }
        public virtual Silnik Silnik { get; set; }
    }
}