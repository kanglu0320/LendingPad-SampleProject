using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IGetOrdersService
    {
        IEnumerable<Order> Get(
            Guid? userId = null,
            OrderStatus? status = null);
    }
}