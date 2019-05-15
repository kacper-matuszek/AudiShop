using AudiShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AudiShop.DataAccess
{
    public class AudiContext : DbContext
    {
        public AudiContext()
            :base("AudiContext"){}

        public DbSet<Model> Modele { get; set; }
        public DbSet<Order> Zamowienia { get; set; }
        public DbSet<OrderDetail> PozycjeZamowienia { get; set; }
        public DbSet<Categoria> Kategorie { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}