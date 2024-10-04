using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Modals;

namespace TechShop.Interfaces
{
    public interface IOrderDetails
    {
        decimal CalculateSubtotal(OrderDetails orderDetail);
        void GetOrderDetailInfo(OrderDetails orderDetail);
        void UpdateQuantity(OrderDetails orderDetail, int newQuantity);
        void AddDiscount(OrderDetails orderDetail, decimal discountPercentage);
    }
}
