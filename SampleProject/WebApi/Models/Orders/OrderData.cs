using BusinessEntities;
using System;
using System.Collections.Generic;

namespace WebApi.Models.Orders
{
    public class OrderData : IdObjectData
    {
        public OrderData(Order order) : base(order)
        {
            Id = order.Id;
            UserId = order.UserId;
            OrderDate = order.OrderDate;
            Status = order.Status;
            TotalAmount = order.TotalAmount;
            ProductIds = order.ProductIds;
        }

        public Guid UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; }

        public decimal TotalAmount { get; set; }

        public IEnumerable<Guid> ProductIds { get; set; }
    }
}