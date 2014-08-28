namespace EF08_Database_Migration.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EF08_Database_Migration.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EF08_Database_Migration.MyDbContext context)
        {
            context.Customers.AddOrUpdate(c => c.Id,
                new Customer()
                {
                    Id = 1,
                    Caption = "Customer #1",
                    DateCreated = DateTime.Now
                },
                new Customer()
                {
                    Id = 2,
                    Caption = "Customer #2",
                    DateCreated = DateTime.Now
                },
                new Customer()
                {
                    Id = 3,
                    Caption = "Customer #3",
                    DateCreated = DateTime.Now
                },
                new Customer()
                {
                    Id = 4,
                    Caption = "Customer #4",
                    DateCreated = DateTime.Now
                });
        }
    }
}
