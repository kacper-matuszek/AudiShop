namespace AudiShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orders : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Order", name: "ApplicationUser_Id", newName: "UserID");
            RenameIndex(table: "dbo.Order", name: "IX_ApplicationUser_Id", newName: "IX_UserID");
            AddColumn("dbo.Order", "Address", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "UserData_Lastname", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_PostalCode", c => c.String(maxLength: 6));
            AlterColumn("dbo.Order", "PhoneNumber", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Order", "Street");
            DropColumn("dbo.AspNetUsers", "UserData_Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserData_Surname", c => c.String());
            AddColumn("dbo.Order", "Street", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Order", "PhoneNumber", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserData_PostalCode");
            DropColumn("dbo.AspNetUsers", "UserData_Lastname");
            DropColumn("dbo.Order", "Address");
            RenameIndex(table: "dbo.Order", name: "IX_UserID", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Order", name: "UserID", newName: "ApplicationUser_Id");
        }
    }
}
