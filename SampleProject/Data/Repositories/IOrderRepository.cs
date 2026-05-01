using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IOrderRepository
    {
        Order Get(Guid id);

        IEnumerable<Order> GetAll();

        IEnumerable<Order> GetList(
            Guid? userId = null,
            OrderStatus? status = null);

        void Save(Order order);

        void Delete(Order order);

        void Delete(Guid id);
    }
}