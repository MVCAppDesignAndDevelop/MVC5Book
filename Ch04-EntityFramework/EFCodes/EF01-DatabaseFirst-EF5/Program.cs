using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF01_DatabaseFirst_EF5
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var query = from item in context.Alphabetical_list_of_products
                            select new
                            {
                                a = item.CategoryName,
                                b = item.ProductName,
                                c = item.QuantityPerUnit
                            };

                foreach (var item in query)
                    Console.WriteLine("a = {0}, b = {1}, c = {2}", item.a, item.b, item.c);
            }
        }
    }
}
