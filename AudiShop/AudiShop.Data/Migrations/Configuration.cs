namespace AudiShop.Data.Migrations
{
    using Defaults;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AudiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "AudiShop.Data.AudiContext";
        }

        protected override void Seed(AudiContext context)
        {

            AudiInitializer.SeedData(context);
            AudiInitializer.SeedUsers(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
