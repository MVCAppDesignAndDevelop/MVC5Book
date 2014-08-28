using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NorthwindDbReader
{
    public class OrderDataOperation : IDataOperation<Order>
    {
        private string _path =
            Environment.CurrentDirectory;
        private string _connectionString =
            @"Server=(localdb)\v11.0; 
                Integrated Security=true; 
                AttachDbFileName=" +
                Environment.CurrentDirectory +
                @"\Northwind.mdf;";

        public IEnumerable<Order> Get()
        {
            IDbConnection connection =
                new SqlConnection(this._connectionString);
            IDbCommand cmd = new SqlCommand("SELECT * FROM Orders");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(
                CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                Order order = new Order()
                {
                    OrderID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("OrderID"))),
                    OrderDate = (reader.IsDBNull(reader.GetOrdinal("OrderDate"))) 
                      ? new Nullable<DateTime>()
                      : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("OrderDate"))),
                    EmployeeID = (reader.IsDBNull(reader.GetOrdinal("EmployeeID"))) 
                      ? new Nullable<int>()
                      : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("EmployeeID"))),
                    Freight = (reader.IsDBNull(reader.GetOrdinal("Freight"))) 
                      ? new Nullable<double>()
                      : Convert.ToDouble(reader.GetValue(reader.GetOrdinal("Freight"))),
                    RequiredDate = (reader.IsDBNull(reader.GetOrdinal("RequiredDate"))) 
                      ? new Nullable<DateTime>()
                      : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("RequiredDate"))),
                    ShipAddress = reader.GetValue(reader.GetOrdinal("CustomerID")).ToString(),
                    ShipCity = reader.GetValue(reader.GetOrdinal("CustomerID")).ToString(),
                    ShipCountry = reader.GetValue(reader.GetOrdinal("CustomerID")).ToString(),
                    ShipName = reader.GetValue(reader.GetOrdinal("CustomerID")).ToString(),
                    ShippedDate = (reader.IsDBNull(reader.GetOrdinal("ShippedDate")))
                      ? new Nullable<DateTime>()
                      : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("ShippedDate"))),
                    ShipPostalCode = reader.GetValue(reader.GetOrdinal("CustomerID")).ToString(),
                    ShipRegion = reader.GetValue(reader.GetOrdinal("CustomerID")).ToString(),
                    ShipVia = (reader.IsDBNull(reader.GetOrdinal("ShipVia"))) 
                      ? new Nullable<int>() 
                      : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ShipVia"))),
                };

                yield return order;
            }

            connection.Close();
        }

        public void Create(Order Item)
        {
            IDbConnection connection =
                new SqlConnection(this._connectionString);
            IDbCommand cmd = new SqlCommand(
                @"INSERT INTO Orders 
                (OrderID, CustomerID, EmployeeID, OrderDate,
                 RequiredDate, ShippedDate, ShipVia, Freight,
                 ShipName, ShipAddress, ShipCity, ShipRegion,
                 ShipPostalCode, ShipCountry)
                VALUES 
                (@OrderID, @CustomerID, @EmployeeID, @OrderDate, 
                 @RequiredDate, @ShippedDate, @ShipVia, @Freight,
                 @ShipName, @ShipAddress, @ShipCity, @ShipRegion, 
                 @ShipPostalCode, @ShipCountry)");

            cmd.Connection = connection;

            cmd.Parameters.Add(
                new SqlParameter("@OrderID", Item.CustomerID));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                   ? new SqlParameter("@CustomerID", DBNull.Value)
                   : new SqlParameter("@CustomerID", Item.CustomerID));
            cmd.Parameters.Add(
                (Item.EmployeeID == null)
                   ? new SqlParameter("@EmployeeID", DBNull.Value)
                   : new SqlParameter("@EmployeeID", Item.EmployeeID));
            cmd.Parameters.Add(
                (Item.OrderDate == null)
                   ? new SqlParameter("@OrderDate", DBNull.Value)
                   : new SqlParameter("@OrderDate", Item.OrderDate));
            cmd.Parameters.Add(
                (Item.RequiredDate == null)
                   ? new SqlParameter("@RequiredDate", DBNull.Value)
                   : new SqlParameter("@RequiredDate", Item.RequiredDate));
            cmd.Parameters.Add(
                (Item.ShippedDate == null)
                   ? new SqlParameter("@ShippedDate", DBNull.Value)
                   : new SqlParameter("@ShippedDate", Item.ShippedDate));
            cmd.Parameters.Add(
                (Item.ShipVia == null)
                   ? new SqlParameter("@ShipVia", DBNull.Value)
                   : new SqlParameter("@ShipVia", Item.ShipVia));
            cmd.Parameters.Add(
                (Item.Freight == null) 
                   ? new SqlParameter("@Freight", DBNull.Value)
                   : new SqlParameter("@Freight", Item.Freight));
            cmd.Parameters.Add(
                new SqlParameter("@ShipName", Item.ShipName));
            cmd.Parameters.Add(
                new SqlParameter("@ShipAddress", Item.ShipAddress));
            cmd.Parameters.Add(
                new SqlParameter("@ShipCity", Item.ShipCity));
            cmd.Parameters.Add(
                new SqlParameter("@ShipRegion", Item.ShipRegion));
            cmd.Parameters.Add(
                new SqlParameter("@ShipPostalCode", Item.ShipPostalCode));
            cmd.Parameters.Add(
                new SqlParameter("@ShipCountry", Item.ShipCountry));

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Order Item)
        {
            IDbConnection connection =
                new SqlConnection(this._connectionString);
            IDbCommand cmd = new SqlCommand(
                @"UPDATE Orders SET
                 CustomerID = @CustomerID, EmployeeID = @EmployeeID, 
                 OrderDate = @OrderDate, RequiredDate = @RequiredDate, 
                 ShippedDate = @ShippedDate, ShipVia = @ShipVia, 
                 Freight = @Freight, ShipName = @ShipName, 
                 ShipAddress = @ShipAddress, ShipCity = @ShipCity, 
                 ShipRegion = @ShipRegion, ShipPostalCode = @ShipPostalCode, 
                 ShipCountry = @ShipCountry
                 WHERE OrderID = @OrderID");

            cmd.Connection = connection;

            cmd.Parameters.Add(
                new SqlParameter("@OrderID", Item.CustomerID));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                   ? new SqlParameter("@CustomerID", DBNull.Value)
                   : new SqlParameter("@CustomerID", Item.CustomerID));
            cmd.Parameters.Add(
                (Item.EmployeeID == null)
                   ? new SqlParameter("@EmployeeID", DBNull.Value)
                   : new SqlParameter("@EmployeeID", Item.EmployeeID));
            cmd.Parameters.Add(
                (Item.OrderDate == null)
                   ? new SqlParameter("@OrderDate", DBNull.Value)
                   : new SqlParameter("@OrderDate", Item.OrderDate));
            cmd.Parameters.Add(
                (Item.RequiredDate == null)
                   ? new SqlParameter("@RequiredDate", DBNull.Value)
                   : new SqlParameter("@RequiredDate", Item.RequiredDate));
            cmd.Parameters.Add(
                (Item.ShippedDate == null)
                   ? new SqlParameter("@ShippedDate", DBNull.Value)
                   : new SqlParameter("@ShippedDate", Item.ShippedDate));
            cmd.Parameters.Add(
                (Item.ShipVia == null)
                   ? new SqlParameter("@ShipVia", DBNull.Value)
                   : new SqlParameter("@ShipVia", Item.ShipVia));
            cmd.Parameters.Add(
                (Item.Freight == null)
                   ? new SqlParameter("@Freight", DBNull.Value)
                   : new SqlParameter("@Freight", Item.Freight));
            cmd.Parameters.Add(
                new SqlParameter("@ShipName", Item.ShipName));
            cmd.Parameters.Add(
                new SqlParameter("@ShipAddress", Item.ShipAddress));
            cmd.Parameters.Add(
                new SqlParameter("@ShipCity", Item.ShipCity));
            cmd.Parameters.Add(
                new SqlParameter("@ShipRegion", Item.ShipRegion));
            cmd.Parameters.Add(
                new SqlParameter("@ShipPostalCode", Item.ShipPostalCode));
            cmd.Parameters.Add(
                new SqlParameter("@ShipCountry", Item.ShipCountry));

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Order Item)
        {
            IDbConnection connection =
                new SqlConnection(this._connectionString);
            IDbCommand cmd = new SqlCommand(
                @"DELETE FROM Orders 
                  WHERE OrderID = @OrderID");

            cmd.Connection = connection;

            cmd.Parameters.Add(
                new SqlParameter("@OrderID", Item.CustomerID));

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
