namespace AudiShop.Migrations
{
    using AudiShop.DataAccess;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AudiShop.DataAccess.AudiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AudiShop.DataAccess.AudiContext";
        }

        protected override void Seed(AudiShop.DataAccess.AudiContext context)
        {

            AudiInitializer.SeedData(context);
            AudiInitializer.SeedUsers(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
