using System;
using BusinessEntities;
using Common;

namespace Core.Services.Products
{
    [AutoRegister]
    public class UpdateProductService : IUpdateProductService
    {
        public void Update(
            Product product,
            string name,
            string description,
            decimal price,
            int stockQuantity)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            product.SetName(name);
            product.SetDescription(description);
            product.SetPrice(price);
            product.SetStockQuantity(stockQuantity);
        }
    }
}