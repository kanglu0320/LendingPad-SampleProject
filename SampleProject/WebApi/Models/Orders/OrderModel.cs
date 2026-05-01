using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        public Guid UserId { get; set; }

        public IEnumerable<Guid> ProductIds { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; }
    }
}