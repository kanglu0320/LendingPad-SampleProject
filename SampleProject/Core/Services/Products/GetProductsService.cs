using System.Collections.Generic;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister]
    public class GetProductsService : IGetProductsService
    {
        private readonly IProductRepository _productRepository;

        public GetProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Get(
            string name = null,
            decimal? minPrice = null,
            decimal? maxPrice = null)
        {
            return _productRepository.GetList(name, minPrice, maxPrice);
        }
    }
}