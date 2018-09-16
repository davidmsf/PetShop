using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Impl
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Create(Order order)
        {
            return _orderRepository.Create(order);
        }

        public void Delete(int id)
        {
            _orderRepository.Delete(id);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.ReadOrders().ToList();
        }

        public Order GetNewOrder()
        {
            return new Order();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public Order Update(Order order)
        {
            return _orderRepository.Update(order);
        }
    }
}
