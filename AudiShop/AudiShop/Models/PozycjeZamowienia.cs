using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudiShop.Models
{
    public class PozycjeZamowienia
    {
        public int PozycjeZamowieniaID { get; set; }
        public int ZamowienieID { get; set; }
        public int ModelID { get; set; }
        public int Ilosc { get; set; }
        public decimal CenaZakupu { get; set; }

        public virtual Model Model { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
    }
}