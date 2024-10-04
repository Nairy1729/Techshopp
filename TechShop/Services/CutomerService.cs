using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Interfaces;
using TechShop.Modals;
using TechShop.Utility;

namespace TechShop.Services
{
    public class CustomerService : ICustomerService
    {
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

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        //constructor
        public CustomerService()
        {
            sqlConnection = new SqlConnection("Server=NAIRY;Database=TechShop2;Trusted_Connection=True");
            //sqlConnection = new SqlConnection(DbConnUtil.GetConnString());
            cmd = new SqlCommand();
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

        public List<Customer> ? GetAllCusto()
        {
            //create a list to hold data from Database
            List<Customer> customer = new List<Customer>();
            cmd.CommandText = "select * from Customers";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Customer customer1 = new Customer();
                customer1.CustomerID = (int)reader["CustomerID"];
                customer1.FirstName = (string)reader["FirstName"];
                customer1.LastName = (string)reader["LastName"];
                customer1.Email = (string)reader["Email"];
                customer1.Phone = (string)reader["Phone"];
                customer1.Address = (string)reader["Address"];
                

                customer.Add(customer1);
            }
            sqlConnection.Close();
            return customer;
        }


    }
}
