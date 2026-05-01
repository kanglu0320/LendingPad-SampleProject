using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IUpdateOrderService
    {
        void Update(
            Order order,
            Guid userId,
            IEnumerable<Guid> productIds,
            decimal totalAmount,
            OrderStatus status);
    }
}