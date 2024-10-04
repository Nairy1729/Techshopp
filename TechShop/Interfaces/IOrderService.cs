using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Modals;

namespace TechShop.Interfaces
{
    public interface IOrderService
    {
        decimal CalculateTotalAmount(Order order);
        void GetOrderDetails(Order order);
        void UpdateOrderStatus(Order order, string status);
        void CancelOrder(Order order);
    }
}
