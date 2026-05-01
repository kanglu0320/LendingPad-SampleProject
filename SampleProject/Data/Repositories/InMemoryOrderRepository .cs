using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        public Order Get(Guid id)
        {
            return InMemoryDataStore.Orders
                .FirstOrDefault(order => order.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return InMemoryDataStore.Orders;
        }

        public IEnumerable<Order> GetList(
            Guid? userId = null,
            OrderStatus? status = null)
        {
            var query = InMemoryDataStore.Orders.AsEnumerable();

            if (userId.HasValue)
            {
                query = query.Where(order => order.UserId == userId.Value);
            }

            if (status.HasValue)
            {
                query = query.Where(order => order.Status == status.Value);
            }

            return query.ToList();
        }

        public void Save(Order order)
        {
            var existingOrder = Get(order.Id);

            if (existingOrder == null)
            {
                InMemoryDataStore.Orders.Add(order);
            }

            // If the order already exists, do nothing.
            // The existing order object has already been updated in memory.
        }

        public void Delete(Order order)
        {
            if (order == null)
            {
                return;
            }

            InMemoryDataStore.Orders.Remove(order);
        }

        public void Delete(Guid id)
        {
            var order = Get(id);

            if (order != null)
            {
                InMemoryDataStore.Orders.Remove(order);
            }
        }
    }
}