namespace AudiShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        PictureName = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Model",
                c => new
                    {
                        ModelID = c.Int(nullable: false, identity: true),
                        CategoriaID = c.Int(nullable: false),
                        EngineID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        CarDrive = c.String(nullable: false),
                        PackageString = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        Color = c.String(),
                        PictureName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ModelID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Engine", t => t.EngineID, cascadeDelete: true)
                .Index(t => t.CategoriaID)
                .Index(t => t.EngineID);
            
            CreateTable(
                "dbo.Engine",
                c => new
                    {
                        EngineID = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Capacity = c.Single(nullable: false),
                        HorsePower = c.Int(nullable: false),
                        KiloWat = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        Emblem = c.String(),
                        AmountCylinders = c.Int(nullable: false),
                        Turbo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EngineID);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ModelID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        PriceValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Model", t => t.ModelID, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ModelID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 100),
                        Street = c.String(nullable: false, maxLength: 100),
                        PostalCode = c.String(nullable: false, maxLength: 6),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Comment = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.OrderDetail", "ModelID", "dbo.Model");
            DropForeignKey("dbo.Model", "EngineID", "dbo.Engine");
            DropForeignKey("dbo.Model", "CategoriaID", "dbo.Categoria");
            DropIndex("dbo.OrderDetail", new[] { "ModelID" });
            DropIndex("dbo.OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.Model", new[] { "EngineID" });
            DropIndex("dbo.Model", new[] { "CategoriaID" });
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Engine");
            DropTable("dbo.Model");
            DropTable("dbo.Categoria");
        }
    }
}
