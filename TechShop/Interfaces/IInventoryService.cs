using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Modals;

namespace TechShop.Interfaces
{
    public interface IInventoryService
    {
        Product GetProduct(Inventory inventoryItem);
        int GetQuantityInStock(Inventory inventoryItem);
        void AddToInventory(Inventory inventoryItem, int quantity);
        void RemoveFromInventory(Inventory inventoryItem, int quantity);
        void UpdateStockQuantity(Inventory inventoryItem, int newQuantity);
        bool IsProductAvailable(Inventory inventoryItem, int quantityToCheck);
        decimal GetInventoryValue(Inventory inventoryItem);

        List<Product> ListLowStockProducts(int threshold);

        List<Product> ListOutOfStockProducts();
        void ListAllProducts();
    }
}
