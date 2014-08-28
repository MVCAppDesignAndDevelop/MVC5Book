using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF08_CustomDbMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MyDbAutoMigration());

            using (var context = new MyDbContext())
            {
                context.Database.Initialize(false);
            }
        }
    }

    public class MyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public DateTime DateCreated { get; set; }
        public string Address { get; set; }
    }

    internal class MyDbAutoMigration : 
        MigrateDatabaseToLatestVersion<MyDbContext, Migrations.Configuration>
    {
    }
}
