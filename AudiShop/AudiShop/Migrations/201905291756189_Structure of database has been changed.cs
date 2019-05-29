namespace AudiShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Structureofdatabasehasbeenchanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Model", "PackageString", c => c.String(nullable: false));
            AlterColumn("dbo.Model", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Model", "CarDrive", c => c.String(nullable: false));
            AlterColumn("dbo.Engine", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Engine", "Emblem", c => c.String());
            DropColumn("dbo.Model", "Package");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Model", "Package", c => c.Int(nullable: false));
            AlterColumn("dbo.Engine", "Emblem", c => c.Int(nullable: false));
            AlterColumn("dbo.Engine", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Model", "CarDrive", c => c.Int(nullable: false));
            AlterColumn("dbo.Model", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.Model", "PackageString");
        }
    }
}
