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
                new Categoria() {CategoriaID = 1, Name ="Sportback",PictureName="Sportback.jpg" },
                new Categoria() {CategoriaID = 2, Name ="Limousine", PictureName="Limousine.jpg" },
                new Categoria() {CategoriaID = 3, Name ="Sport", PictureName="Sport.jpg" },
                new Categoria() {CategoriaID = 4, Name ="Avant", PictureName="Avant.jpg" },
                new Categoria() {CategoriaID = 5, Name ="Allroad", PictureName="Allroad.jpg" },
                new Categoria() {CategoriaID = 6, Name ="Coupé", PictureName="Coupé.jpg" },
                new Categoria() {CategoriaID = 7, Name ="SUV", PictureName="SUV.jpg" },
                new Categoria() {CategoriaID = 8, Name ="Sedan", PictureName="Sedan.jpg" }
            };

            categories.ForEach(c => context.Categories.AddOrUpdate(c));
            context.SaveChanges();

            var engines = new List<Engine>
            {
                /* Petrol*/
                new Engine() {EngineID = 1, Code = 25, Capacity = 1.0f, Emblem = EmblemType.TFSI, HorsePower = 95, KiloWat = 70,
                Turbo = true, AmountCylinders = 3, Type = EngineType.Petrol},
                new Engine() {EngineID = 2, Code = 30, Capacity = 1.0f, Emblem = EmblemType.TFSI, HorsePower = 116, KiloWat = 85,
                Turbo = true, AmountCylinders = 3, Type = EngineType.Petrol},
                new Engine() {EngineID = 3, Code = 35, Capacity = 1.5f, Emblem = EmblemType.TFSI, HorsePower = 150, KiloWat = 110,
                Turbo = true, AmountCylinders = 4, Type = EngineType.Petrol},
                new Engine() {EngineID = 4, Code = 40, Capacity = 2.0f, Emblem = EmblemType.TFSI, HorsePower = 200, KiloWat = 147,
                Turbo = true, AmountCylinders = 4, Type = EngineType.Petrol}, 
                new Engine() {EngineID = 5, Capacity = 1.4f, Emblem = EmblemType.TFSI, HorsePower = 204, KiloWat = 150,
                Turbo = true, AmountCylinders = 4, Type = EngineType.Petrol},
                new Engine() {EngineID = 6, Capacity = 2.0f, Emblem = EmblemType.TFSI, HorsePower = 300, KiloWat = 221,
                Turbo = true, AmountCylinders = 4, Type = EngineType.Petrol},
                new Engine() {EngineID = 7, Capacity = 2.5f, Emblem = EmblemType.TFSI, HorsePower = 400, KiloWat = 294,
                Turbo = true, AmountCylinders = 5, Type = EngineType.Petrol},
                new Engine() {EngineID = 8, Code = 35, Capacity = 2.0f, Emblem = EmblemType.TFSI, HorsePower = 150, KiloWat = 110,
                Turbo = true, AmountCylinders = 4, Type = EngineType.Petrol},
                new Engine() {EngineID = 9, Code = 40, Capacity = 2.0f, Emblem = EmblemType.TFSI, HorsePower = 190, KiloWat = 140,
                Turbo = true, AmountCylinders = 4, Type = EngineType.Petrol},
                new Engine() {EngineID = 10, Code = 45, Capacity = 2.0f, Emblem = EmblemType.TFSI, HorsePower = 245, KiloWat = 180,
                Turbo = true, AmountCylinders = 4, Type = EngineType.Petrol},
                new Engine() {EngineID = 11, Capacity = 3.0f, Emblem = EmblemType.TFSI, HorsePower = 354, KiloWat = 260,
                Turbo = true, AmountCylinders = 6, Type = EngineType.Petrol},
                new Engine() {EngineID = 12, Capacity = 2.9f, Emblem = EmblemType.TFSI, HorsePower = 450, KiloWat = 331,
                Turbo = true, AmountCylinders = 6, Type = EngineType.Petrol},
                new Engine() {EngineID = 13, Code = 55, Capacity = 3.0f, Emblem = EmblemType.TFSI, HorsePower = 340, KiloWat = 250,
                Turbo = true, AmountCylinders = 6, Type = EngineType.Petrol},
                /*Petrol*/

                /*Diesel*/
                new Engine() {EngineID = 14, Code = 35, Capacity = 2.0f, Emblem = EmblemType.TDI, HorsePower = 150, KiloWat = 110,
                Turbo = true, AmountCylinders = 4, Type = EngineType.Diesel},
                new Engine() {EngineID = 15, Code = 40, Capacity = 2.0f, Emblem = EmblemType.TDI, HorsePower = 190, KiloWat = 140,
                Turbo = true, AmountCylinders = 4, Type = EngineType.Diesel},
                new Engine() {EngineID = 16, Code = 40, Capacity = 2.0f, Emblem = EmblemType.TDI, HorsePower = 204, KiloWat = 150,
                Turbo = true, AmountCylinders = 4, Type = EngineType.Diesel },
                new Engine() {EngineID = 17, Capacity = 3.0f, Emblem = EmblemType.TDI, HorsePower = 347, KiloWat = 255,
                Turbo = true, AmountCylinders = 6, Type = EngineType.Diesel},
                new Engine() {EngineID = 18, Code = 50, Capacity = 3.0f, Emblem = EmblemType.TDI, HorsePower = 286, KiloWat = 210,
                Turbo = true, AmountCylinders = 6, Type = EngineType.Diesel},
                new Engine() {EngineID = 19, Code = 45, Capacity = 3.0f, Emblem = EmblemType.TDI, HorsePower = 231, KiloWat = 170,
                Turbo = true, AmountCylinders = 6, Type = EngineType.Diesel}
                /*Diesel*/
            };

            engines.ForEach(e => context.Engines.AddOrUpdate(e));
            context.SaveChanges();

            var models = new List<Model>
            {
                /* Petrol Models*/
                new Model() {ModelID = 1, Name = ModelType.A1, CarDrive = CarDriveType.FrontAxle, CategoriaID = 1,
                CreatedDate = DateTime.Now, Available = true, EngineID = 1, Package = PackageType.Sportback, Price = 87300, Description="Sportback"},
                new Model() {ModelID = 2, Name = ModelType.A1, CarDrive = CarDriveType.FrontAxle, CategoriaID = 1,
                CreatedDate = DateTime.Now, Available = true, EngineID = 3, Package = PackageType.Sportback, Price = 106600, Description="Sportback"},
                new Model() {ModelID = 3, Name = ModelType.A1, CarDrive = CarDriveType.FrontAxle, CategoriaID = 1,
                CreatedDate = DateTime.Now, Available = true, EngineID = 4, Package = PackageType.SLine, Price = 127000, Description="S-Line"},
                new Model() {ModelID =  4, Name = ModelType.A3, EngineID = 3, CarDrive = CarDriveType.FrontAxle, CategoriaID = 1,
                CreatedDate = DateTime.Now, Available = true, Package = PackageType.Standard, Price = 112400, Description="Standard Version"},
                new Model() {ModelID = 5, Name = ModelType.A3, EngineID = 7, CarDrive = CarDriveType.Quattro, CategoriaID = 2,
                CreatedDate = DateTime.Now, Available = true, Package = PackageType.Standard, Price = 274300, Description = "Standar Version"},
                new Model() {ModelID = 6, Name = ModelType.A3, EngineID=12, CarDrive = CarDriveType.Quattro, CategoriaID=1,
                CreatedDate = DateTime.Now, Available = true, Package = PackageType.Sportback, Price = 480000, Description="Latest"}
                /*Petrol Models*/
            };

            models.ForEach(m => context.Models.AddOrUpdate(m));
            context.SaveChanges();

        }
    }
}