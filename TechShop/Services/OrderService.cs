using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Interfaces;
using TechShop.Modals;

namespace TechShop.Services
{
    public class OrderService : IOrderService
    {
        public decimal CalculateTotalAmount(Order order)
        {
            decimal totalAmount = 0;

            foreach (var detail in order.OrderDetails)
            {
                totalAmount += detail.Quantity * detail.Product.Price;
            }

            return totalAmount;
        }

        public void GetOrderDetails(Order order)
        {
            Console.WriteLine($"Order ID: {order.OrderID}");
            Console.WriteLine($"Order Date: {order.OrderDate}");
            Console.WriteLine($"Total Amount: {CalculateTotalAmount(order):C}");
            Console.WriteLine("Product List:");
            foreach (var detail in order.OrderDetails)
            {
                Console.WriteLine($"- {detail.Product.ProductName}: {detail.Quantity}");
            }
        }

        public void UpdateOrderStatus(Order order, string status)
        {
            order.OrderStatus = status;
            Console.WriteLine("Order status updated successfully.");
        }

        public void CancelOrder(Order order)
        {
            Console.WriteLine($"Order {order.OrderID} has been cancelled.");
        }
    }
}
