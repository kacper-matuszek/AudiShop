using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudiShop.Models
{
    public class Zamowienie
    {
        public int ZamowienieID { get; set; }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string KodPocztowy { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Komentarz { get; set; }

        public DateTime DataDodania { get; set; }
        public StatusZamowienia Status { get; set; }
        public decimal Wartosc { get; set; }

        public List<PozycjeZamowienia> PozycjeZamowienia { get; set; }
    }

    public enum StatusZamowienia
    {
        Nowe,
        Zrealizowane
    }
}