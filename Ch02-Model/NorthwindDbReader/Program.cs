using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NorthwindDbReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Northwind db = new Northwind();
            IEnumerable<Customer> customers = db.Customers.Get();
            IEnumerable<Order> orders = db.Orders.Get();

            foreach (Customer customer in customers)
                Console.WriteLine("Customer: {0}", customer.CustomerID);
            foreach (Order order in orders)
                Console.WriteLine("Order: {0}", order.OrderID);

            Console.ReadLine();
        }
    } 
}
