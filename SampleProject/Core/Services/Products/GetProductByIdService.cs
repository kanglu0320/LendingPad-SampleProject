using System;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister]
    public class GetProductByIdService : IGetProductByIdService
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Get(Guid id)
        {
            return _productRepository.Get(id);
        }
    }
}