using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF08_Database_Initializer
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MyDbInitializer());

            using (var context = new MyDbContext())
            {
                context.Database.Initialize(true);
            }
        }
    }

    public class MyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public DateTime DateCreated { get; set; }
        public string Address { get; set; }
    }
}
