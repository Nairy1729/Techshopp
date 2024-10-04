using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Modals;
using TechShop.Interfaces;

namespace TechShop.Services
{
    public class OrderDetailsService : IOrderDetails
    {
        public decimal CalculateSubtotal(OrderDetails orderDetail)
        {
            return orderDetail.Quantity * orderDetail.Product.Price;
        }

        public void GetOrderDetailInfo(OrderDetails orderDetail)
        {
            Console.WriteLine($"Order Detail ID: {orderDetail.OrderDetailID}");
            Console.WriteLine($"Product: {orderDetail.Product.ProductName}");
            Console.WriteLine($"Quantity: {orderDetail.Quantity}");
            Console.WriteLine($"Subtotal: {CalculateSubtotal(orderDetail):C}"); 
        }

        public void UpdateQuantity(OrderDetails orderDetail, int newQuantity)
        {
            orderDetail.Quantity = newQuantity; 
            Console.WriteLine("Quantity updated successfully.");
        }

        public void AddDiscount(OrderDetails orderDetail, decimal discountPercentage)
        {
            decimal subtotal = CalculateSubtotal(orderDetail);
            decimal discountAmount = subtotal * (discountPercentage / 100);
            Console.WriteLine($"Discount applied: {discountAmount:C}");
            Console.WriteLine($"New subtotal after discount: {subtotal - discountAmount:C}");
        }
    }
}
