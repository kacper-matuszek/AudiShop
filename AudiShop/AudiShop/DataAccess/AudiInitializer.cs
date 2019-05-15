using AudiShop.Migrations;
using AudiShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace AudiShop.DataAccess
{
    class AudiInitializer : MigrateDatabaseToLatestVersion<AudiContext, Configuration>
    {

        public static void SeedData(AudiContext context)
        {
            var categories = new List<Categoria>
            {
                new Categoria() {CategoriaID = 1, Name ="Sportback" },
                new Categoria() {CategoriaID = 2, Name ="Limousine" },
                new Categoria() {CategoriaID = 3, Name ="Sport" },
                new Categoria() {CategoriaID = 4, Name ="Avant" },
                new Categoria() {CategoriaID = 5, Name ="Allroad" },
                new Categoria() {CategoriaID = 6, Name ="Coupé" },
                new Categoria() {CategoriaID = 7, Name ="SUV" },
                new Categoria() {CategoriaID = 8, Name ="Sedan" }
            };

            categories.ForEach(c => context.Categories.AddOrUpdate(c));
            context.SaveChanges();

            var models = new List<Engine>
            {
                new Engine() {EngineID = 1, Capacity = 25, Emblem = EmblemType.TFSI, HorsePower = 95, KiloWat = 70,
                Turbo = true, Type = EngineType.Petrol},
                new Engine() {EngineID = 2, Capacity = 30, Emblem = EmblemType.TFSI, HorsePower = 116, KiloWat = 85,
                Turbo = true, Type = EngineType.Petrol},
                new Engine() {EngineID = 3, Capacity = 35, Emblem = EmblemType.TFSI, HorsePower = 150, KiloWat = 110,
                Turbo = true, Type = EngineType.Petrol}
            };

        }
    }
}