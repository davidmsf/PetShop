using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    interface IOrderService
    {

        List<Order> GetAllOrders();

        void Delete(int id);

        Order GetOrderById(int id);

        Order GetNewOrder();

        Order Create(Order order);

        Order Update(Order order);
    }
}
