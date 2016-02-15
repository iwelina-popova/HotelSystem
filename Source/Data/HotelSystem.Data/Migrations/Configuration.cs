namespace HotelSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<HotelSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HotelSystemDbContext context)
        {
               // DataSeeder.SeedUsers(context);
                DataSeeder.SeedRooms(context);
                DataSeeder.SeedHotels(context);
        }
    }
}
