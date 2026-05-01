using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface IGetProductsService
    {
        IEnumerable<Product> Get(
            string name = null,
            decimal? minPrice = null,
            decimal? maxPrice = null);
    }
}
