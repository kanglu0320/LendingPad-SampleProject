using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class UpdateOrderService : IUpdateOrderService
    {
        public void Update(
            Order order,
            Guid userId,
            IEnumerable<Guid> productIds,
            decimal totalAmount,
            OrderStatus status)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            order.SetUserId(userId);
            order.SetProductIds(productIds);
            order.SetTotalAmount(totalAmount);
            order.SetStatus(status);
        }
    }
}