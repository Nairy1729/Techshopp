using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Interfaces;
using TechShop.Modals;

namespace TechShop.Services
{
    public class ProductService : IProductService
    {
        public void GetProductDetails(Product product)
        {
            Console.WriteLine($"Product ID: {product.ProductID}");
            Console.WriteLine($"Product Name: {product.ProductName}");
            Console.WriteLine($"Description: {product.Description}");
            Console.WriteLine($"Price: {product.Price:C}");
        }

        public void UpdateProductInfo(Product product, decimal price, string description)
        {
            product.Price = price;
            product.Description = description;
            Console.WriteLine("Product information updated successfully.");
        }

        public bool IsProductInStock(Product product)
        {
            return product.Price > 0;
        }
    }
}
