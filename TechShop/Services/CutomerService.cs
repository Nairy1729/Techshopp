using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Interfaces;
using TechShop.Modals;
using TechShop.util;

namespace TechShop.Services
{
    public class CustomerService : ICustomerService
    {

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public CustomerService()
        {
            sqlConnection = DBConnection.GetConnection("C:\\Users\\nairy\\source\\repos\\Techshopp\\TechShop\\util\\dbconfig.json");
            cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
        }

        public List<Customer> GetAllCusto()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                // Open the connection
                //sqlConnection.Open();

                // Execute the query
                cmd.CommandText = "SELECT * FROM Customers";
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();

                // Process the results
                while (reader.Read())
                {
                    Customer customer1 = new Customer
                    {
                        CustomerID = (int)reader["CustomerID"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Email = (string)reader["Email"],
                        Phone = (string)reader["Phone"],
                        Address = (string)reader["Address"]
                    };

                    customers.Add(customer1);
                }

                // Close the reader after processing
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return customers;
        }









        private List<Order> orders = new List<Order>();

        public int CalculateTotalOrders(Customer customer)
        {
            return orders.Count(o => o.Customer.CustomerID == customer.CustomerID);
        }

        public void UpdateCustomerInfo(Customer customer, string email, string phone, string address)
        {
            customer.Email = email;
            customer.Phone = phone;
            customer.Address = address;
            Console.WriteLine("Customer information updated successfully.");
        }

        

        public void GetCustomerDetails(Customer customer)
        {
            Console.WriteLine($"Customer ID: {customer.CustomerID}");
            Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Phone: {customer.Phone}");
            Console.WriteLine($"Address: {customer.Address}");
            Console.WriteLine($"Total Orders: {CalculateTotalOrders(customer)}");


        }




    }
}
