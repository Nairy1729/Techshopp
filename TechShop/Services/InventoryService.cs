using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Interfaces;
using TechShop.Modals;

namespace TechShop.Services
{
    public class InventoryService : IInventoryService
    {
        
        
            public Product GetProduct(Inventory inventoryItem)
            {
                return inventoryItem.Product;
            }

            public int GetQuantityInStock(Inventory inventoryItem)
            {
                return inventoryItem.QuantityInStock;
            }

            public void AddToInventory(Inventory inventoryItem, int quantity)
            {
                inventoryItem.QuantityInStock += quantity;
                inventoryItem.LastStockUpdate = DateTime.Now;
                Console.WriteLine($"{quantity} units added to inventory for product {inventoryItem.Product.ProductName}.");
            }

            public void RemoveFromInventory(Inventory inventoryItem, int quantity)
            {
                if (quantity > inventoryItem.QuantityInStock)
                {
                    Console.WriteLine("Cannot remove more than available in stock.");
                }
                else
                {
                    inventoryItem.QuantityInStock -= quantity;
                    inventoryItem.LastStockUpdate = DateTime.Now;
                    Console.WriteLine($"{quantity} units removed from inventory for product {inventoryItem.Product.ProductName}.");
                }
            }

            public void UpdateStockQuantity(Inventory inventoryItem, int newQuantity)
            {
                inventoryItem.QuantityInStock = newQuantity;
                inventoryItem.LastStockUpdate = DateTime.Now;
                Console.WriteLine($"Stock quantity for product {inventoryItem.Product.ProductName} updated to {newQuantity}.");
            }

            public bool IsProductAvailable(Inventory inventoryItem, int quantityToCheck)
            {
                return inventoryItem.QuantityInStock >= quantityToCheck;
            }

            public decimal GetInventoryValue(Inventory inventoryItem)
            {
                return inventoryItem.QuantityInStock * inventoryItem.Product.Price;
            }

            public List<Product> ListLowStockProducts(int threshold)
            {
                List<Product> lowStockProducts = new List<Product>();
                foreach (var item in Inventory.InventoryItems)
                {
                    if (item.QuantityInStock < threshold)
                    {
                        lowStockProducts.Add(item.Product);
                    }
                }
                return lowStockProducts;
            }

            public List<Product> ListOutOfStockProducts()
            {
                List<Product> outOfStockProducts = new List<Product>();
                foreach (var item in Inventory.InventoryItems)
                {
                    if (item.QuantityInStock == 0)
                    {
                        outOfStockProducts.Add(item.Product);
                    }
                }
                return outOfStockProducts;
            }

            public void ListAllProducts()
            {
                Console.WriteLine("All Products in Inventory:");
                foreach (var item in Inventory.InventoryItems)
                {
                    Console.WriteLine($"Product: {item.Product.ProductName}, Quantity: {item.QuantityInStock}");
                }
            }
        }
    }

