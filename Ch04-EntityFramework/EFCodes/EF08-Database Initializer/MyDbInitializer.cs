using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EF08_Database_Initializer
{
    public class MyDbInitializer : IDatabaseInitializer<MyDbContext>
    {
        public void InitializeDatabase(MyDbContext context)
        {
            context.Database.CreateIfNotExists();

            context.Customers.Add(new Customer()
                {
                    Id = 1,
                    Caption = "Customer #1",
                    DateCreated = DateTime.Now
                });

            context.SaveChanges();
        }
    }
}
