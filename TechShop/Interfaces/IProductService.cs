using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Modals;

namespace TechShop.Interfaces
{
    public interface IProductService
    {
        void GetProductDetails(Product product);
        void UpdateProductInfo(Product product, decimal price, string description);
        bool IsProductInStock(Product product);
    }
}
