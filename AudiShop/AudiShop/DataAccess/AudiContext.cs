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

        public DbSet<Model> Models { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Categoria> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}