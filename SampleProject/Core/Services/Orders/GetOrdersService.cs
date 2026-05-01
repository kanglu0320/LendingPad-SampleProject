using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class GetOrdersService : IGetOrdersService
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> Get(
            Guid? userId = null,
            OrderStatus? status = null)
        {
            return _orderRepository.GetList(userId, status);
        }
    }
}