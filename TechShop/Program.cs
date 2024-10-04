

using TechShop.Modals;
using TechShop.Services;

namespace TechShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of your data access class (replace 'YourDataAccessClass' with the actual class name)
            var customerService = new CustomerService(); // Change this to your actual class name

            try
            {
                // Call the GetAllCustomers method to retrieve customer data
                List<Customer> customers = customerService.GetAllCusto();

                // Display the retrieved customer details
                Console.WriteLine("Customer List:");
                Console.WriteLine(new string('-', 40));
                foreach (var customer in customers)
                {
                    Console.WriteLine($"ID: {customer.CustomerID}");
                    Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($"Email: {customer.Email}");
                    Console.WriteLine($"Phone: {customer.Phone}");
                    Console.WriteLine($"Address: {customer.Address}");
                    Console.WriteLine(new string('-', 40));
                }

                if (customers.Count == 0)
                {
                    Console.WriteLine("No customers found.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during execution
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            // Wait for user input before closing the console
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

}

