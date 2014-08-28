using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF07_DataContext
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Northwind())
            {
                // object-based query.
                var queryLINQ = context.Customers.Where(c => c.CustomerID == "ALFKI").ToList();
                var queryFind = context.Customers.Find("ALFKI");

                //Stopwatch loadingWatch = new Stopwatch();

                //loadingWatch.Start();

                //// navigation property lazy loading.
                //var queryOrdersLazyLoading = context.Orders;

                //foreach (var queryOrder in queryOrdersLazyLoading)
                //    queryOrder.Order_Details.AsQueryable().Load(); // Lazy Loading.

                //loadingWatch.Stop();
                //Console.WriteLine("Lazy Loading for Order.Order_Details: {0}ms", loadingWatch.ElapsedMilliseconds);
                //loadingWatch.Reset();
                //loadingWatch.Start();

                //// navigation property eager loading.
                //var queryOrdersEagerLoading = context.Orders.Include(c => c.Order_Details); // eager loading

                //foreach (var queryOrder in queryOrdersEagerLoading)
                //    queryOrder.Order_Details.ToList();

                //loadingWatch.Stop();
                //Console.WriteLine("Eager Loading for Order.Order_Details: {0}ms", loadingWatch.ElapsedMilliseconds);

                // query by SQL with named parameter.
                var querySql = context.Database.SqlQuery<Customer>("SELECT * FROM Customers WHERE CustomerID = @id", new SqlParameter("@id", "ALFKI"));

                // query stored procedure with named parameter
                var querySP = context.Database.SqlQuery<CustOrderHistDTO>("EXEC dbo.CustOrderHist @CustomerID", new SqlParameter("@CustomerID", "ALFKI"));

                //foreach (var item in querySP)
                //    Console.WriteLine("Name: {0}, Total: {1}", item.ProductName, item.Total);

                // query by low-level context.
                var rawSqlCmd = context.Database.Connection.CreateCommand();
                rawSqlCmd.CommandText = "dbo.CustOrderHist";
                rawSqlCmd.CommandType = CommandType.StoredProcedure;
                rawSqlCmd.Parameters.Add(new SqlParameter("@CustomerID", "ALFKI"));

                rawSqlCmd.Connection.Open();
                
                var reader = rawSqlCmd.ExecuteReader();

                //while (reader.Read())
                //    Console.WriteLine("Name: {0}, Total: {1}", reader.GetValue(0), reader.GetValue(1));

                rawSqlCmd.Connection.Close();

                // control entity state.
                var querySqlES = context.Customers.Where(c => c.CustomerID == "ALFKI");
                var customerItem = querySqlES.First();

                //customerItem.Country = "Taiwan";
                //Console.WriteLine("Original Value: {0}, Current Value: {1}, Database Value: {2}",
                //   context.Entry(customerItem).Property(c => c.Country).OriginalValue,
                //   context.Entry(customerItem).Property(c => c.Country).CurrentValue,
                //   context.Entry(customerItem).GetDatabaseValues().GetValue<string>("Country"));

                //customerItem.CustomerID = null;
                //// get entity errors.
                //var validationResult = context.Entry(customerItem).GetValidationResult();
                //// get property validation errors.
                //var errors = context.Entry(customerItem).Property(c => c.CustomerID).GetValidationErrors();

                //customerItem.CustomerID = "ALFKI";

                // test IValidatableObject implementation (refer Customer.cs file).
                customerItem.Country = "KOREA";
                var countryValidationResult = context.Entry(customerItem).GetValidationResult();

                Console.WriteLine("Entity Validation Errors:");

                if (countryValidationResult.IsValid)
                    Console.WriteLine("PASS!!");
                else
                {
                    foreach (var error in countryValidationResult.ValidationErrors)
                        Console.WriteLine("error: {0}", error.ErrorMessage);
                }
            }
                       

            Console.Read();
        }
    }

    public class CustOrderHistDTO
    {
        public string ProductName { get; set; }
        public int Total { get; set; }
    }
}
