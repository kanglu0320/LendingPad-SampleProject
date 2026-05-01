using System;
using System.Collections.Generic;
using Common.Extensions;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        private readonly List<Guid> _productIds = new List<Guid>();
        private Guid _userId;
        private DateTime _orderDate;
        private OrderStatus _status = OrderStatus.Created;
        private decimal _totalAmount;

        public Guid UserId
        {
            get => _userId;
            private set => _userId = value;
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            private set => _orderDate = value;
        }

        public OrderStatus Status
        {
            get => _status;
            private set => _status = value;
        }

        public decimal TotalAmount
        {
            get => _totalAmount;
            private set => _totalAmount = value;
        }

        public IEnumerable<Guid> ProductIds
        {
            get => _productIds;
            private set => _productIds.Initialize(value);
        }

        public void SetUserId(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentException("User id was not provided.");
            }

            _userId = userId;
        }

        public void SetOrderDate(DateTime orderDate)
        {
            if (orderDate == default(DateTime))
            {
                throw new ArgumentException("Order date was not provided.");
            }

            _orderDate = orderDate;
        }

        public void SetStatus(OrderStatus status)
        {
            _status = status;
        }

        public void SetTotalAmount(decimal totalAmount)
        {
            if (totalAmount < 0)
            {
                throw new ArgumentException("Total amount cannot be negative.");
            }

            _totalAmount = totalAmount;
        }

        public void SetProductIds(IEnumerable<Guid> productIds)
        {
            _productIds.Initialize(productIds);
        }
    }
}