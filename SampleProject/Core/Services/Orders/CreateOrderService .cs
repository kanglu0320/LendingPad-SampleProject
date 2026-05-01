using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IIdObjectFactory<Order> _orderFactory;
        private readonly IOrderRepository _orderRepository;
        private readonly IUpdateOrderService _updateOrderService;

        public CreateOrderService(
            IIdObjectFactory<Order> orderFactory,
            IOrderRepository orderRepository,
            IUpdateOrderService updateOrderService)
        {
            _orderFactory = orderFactory;
            _orderRepository = orderRepository;
            _updateOrderService = updateOrderService;
        }

        public Order Create(
            Guid id,
            Guid userId,
            IEnumerable<Guid> productIds,
            decimal totalAmount,
            OrderStatus status)
        {
            var existingOrder = _orderRepository.Get(id);

            if (existingOrder != null)
            {
                throw new InvalidOperationException($"Order with id {id} already exists.");
            }

            var order = _orderFactory.Create(id);

            order.SetOrderDate(DateTime.UtcNow);

            _updateOrderService.Update(
                order,
                userId,
                productIds,
                totalAmount,
                status);

            _orderRepository.Save(order);

            return order;
        }
    }
}