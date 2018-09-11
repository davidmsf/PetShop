using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        public Order Create(Order order)
        {
            order.Id = FakeDB.orderId++;
            var orders = FakeDB.orders.ToList();
            orders.Add(order);
            FakeDB.orders = orders;
            return order;
        }

        public void Delete(int id)
        {
            var orders = FakeDB.orders.ToList();
            var orderToDelete = orders.FirstOrDefault(order => order.Id == id);
            orders.Remove(orderToDelete);
            FakeDB.orders = orders;
        }

        public Order GetOrderById(int id)
        {
            var selectedOrder = FakeDB.orders.FirstOrDefault(order => order.Id == id);
            return selectedOrder;
        }

        public IEnumerable<Order> ReadOrders()
        {
            return FakeDB.orders;
        }

        public Order Update(Order updatedOrder)
        {
            return updatedOrder;
        }
    }
}
