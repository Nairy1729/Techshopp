using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Modals;

namespace TechShop.Interfaces
{
    public interface ICustomerService
    {
        int CalculateTotalOrders(Customer customer);
        void UpdateCustomerInfo(Customer customer, string email, string phone, string address);
        void GetCustomerDetails(Customer customer);


    }
}
