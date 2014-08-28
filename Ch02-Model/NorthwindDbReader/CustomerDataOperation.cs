using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NorthwindDbReader
{
    public class CustomerDataOperation : IDataOperation<Customer>
    {
        private string _path =
            Environment.CurrentDirectory;
        private string _connectionString = 
            @"Server=(localdb)\v11.0; 
                Integrated Security=true; 
                AttachDbFileName=" + 
                Environment.CurrentDirectory + 
                @"\Northwind.mdf;";

        public IEnumerable<Customer> Get()
        {
            IDbConnection connection = 
                new SqlConnection(this._connectionString);
            IDbCommand cmd = new SqlCommand("SELECT * FROM Customers");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(
                CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                Customer customer = new Customer()
                {
                    CustomerID = reader.GetValue(reader.GetOrdinal("CustomerID")).ToString(),
                    CompanyName = reader.GetValue(reader.GetOrdinal("CompanyName")).ToString(),
                    Address = reader.GetValue(reader.GetOrdinal("Address")).ToString(),
                    City = reader.GetValue(reader.GetOrdinal("City")).ToString(),
                    ContactName = reader.GetValue(reader.GetOrdinal("ContactName")).ToString(),
                    ContactTitle = reader.GetValue(reader.GetOrdinal("ContactTitle")).ToString(),
                    Country = reader.GetValue(reader.GetOrdinal("Country")).ToString(),
                    Fax = reader.GetValue(reader.GetOrdinal("Fax")).ToString(),
                    Phone = reader.GetValue(reader.GetOrdinal("Phone")).ToString(),
                    PostalCode = reader.GetValue(reader.GetOrdinal("PostalCode")).ToString(),
                    Region = reader.GetValue(reader.GetOrdinal("Region")).ToString()
                };

                yield return customer;
            }

            connection.Close();
        }

        public void Create(Customer Item)
        {
            IDbConnection connection = 
                new SqlConnection(this._connectionString);
            IDbCommand cmd = new SqlCommand(
                @"INSERT INTO Customers 
                (CustomerID, CompanyName, Address, City, ContactName, 
                    ContactTitle, Country, Fax, Phone, PostalCode, Region)
                VALUES 
                (@CustomerID, @CompanyName, @Address, @City, @ContactName, 
                    @ContactTitle, @Country, @Fax, @Phone, @PostalCode, @Region)");

            cmd.Connection = connection;

            cmd.Parameters.Add(
                new SqlParameter("@CustomerID", Item.CustomerID));
            cmd.Parameters.Add(
                new SqlParameter("@CompanyName", Item.CompanyName));
            cmd.Parameters.Add(
                new SqlParameter("@Address", Item.Address));
            cmd.Parameters.Add(
                new SqlParameter("@City", Item.City));
            cmd.Parameters.Add(
                new SqlParameter("@ContactName", Item.ContactName));
            cmd.Parameters.Add(
                new SqlParameter("@ContactTitle", Item.ContactTitle));
            cmd.Parameters.Add(
                new SqlParameter("@Country", Item.Country));
            cmd.Parameters.Add(
                new SqlParameter("@Fax", Item.Fax));
            cmd.Parameters.Add(
                new SqlParameter("@Phone", Item.Phone));
            cmd.Parameters.Add(
                new SqlParameter("@PostalCode", Item.PostalCode));
            cmd.Parameters.Add(
                new SqlParameter("@Region", Item.Region));

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Customer Item)
        {
            IDbConnection connection = 
                new SqlConnection(this._connectionString);
            IDbCommand cmd = new SqlCommand(
                @"UPDATE Customers SET 
                            CompanyName = @CompanyName, Address = @Address, 
                            City = @City, ContactName = @ContactName, 
                            ContactTitle = @ContactTitle, Country = @Country, 
                            Fax = @Fax, Phone = @Phone, 
                            PostalCode = @PostalCode, Region = @Region
                    WHERE   CustomerID = @CustomerID");

            cmd.Connection = connection;

            cmd.Parameters.Add(
                new SqlParameter("@CustomerID", Item.CustomerID));
            cmd.Parameters.Add(
                new SqlParameter("@CompanyName", Item.CompanyName));
            cmd.Parameters.Add(
                new SqlParameter("@Address", Item.Address));
            cmd.Parameters.Add(
                new SqlParameter("@City", Item.City));
            cmd.Parameters.Add(
                new SqlParameter("@ContactName", Item.ContactName));
            cmd.Parameters.Add(
                new SqlParameter("@ContactTitle", Item.ContactTitle));
            cmd.Parameters.Add(
                new SqlParameter("@Country", Item.Country));
            cmd.Parameters.Add(
                new SqlParameter("@Fax", Item.Fax));
            cmd.Parameters.Add(
                new SqlParameter("@Phone", Item.Phone));
            cmd.Parameters.Add(
                new SqlParameter("@PostalCode", Item.PostalCode));
            cmd.Parameters.Add(
                new SqlParameter("@Region", Item.Region));

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Customer Item)
        {
            IDbConnection connection = 
                new SqlConnection(this._connectionString);
            IDbCommand cmd = new SqlCommand(
                @"DELETE FROM Customers WHERE CustomerID = @CustomerID");

            cmd.Connection = connection;

            cmd.Parameters.Add(
                new SqlParameter("@CustomerID", Item.CustomerID));

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
