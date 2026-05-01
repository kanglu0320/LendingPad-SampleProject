using System;
using Common;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class DeleteOrderService : IDeleteOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Delete(Guid id)
        {
            var order = _orderRepository.Get(id);

            if (order == null)
            {
                throw new InvalidOperationException($"Order with id {id} was not found.");
            }

            _orderRepository.Delete(order);
        }
    }
}