using AudiShop.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AudiShop.DataAccess
{
    public class AudiContext : IdentityDbContext<ApplicationUser>
    {
        public AudiContext()
            :base("AudiContext"){
            AppDomain.CurrentDomain.SetData("DataDirectory", "E:\\Microsoft SQL Server\\MSSQL14.KAC_DATA\\MSSQL\\DATA\\");
        }

        public static AudiContext Create()
        {
            return new AudiContext();
        }

        public DbSet<Model> Models { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Categoria> Categories { get; set; }

        static AudiContext()
        {
            Database.SetInitializer<AudiContext>(new AudiInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}