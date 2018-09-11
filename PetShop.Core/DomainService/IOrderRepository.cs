using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IOrderRepository
    {
        Order Create(Order order);

        IEnumerable<Order> ReadOrders();

        void Delete(int id);

        Order GetOrderById(int id);

        Order Update(Order order);
    }
}
