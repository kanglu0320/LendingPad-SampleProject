using System;
using Common;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister]
    public class DeleteProductService : IDeleteProductService
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Delete(Guid id)
        {
            var product = _productRepository.Get(id);

            if (product == null)
            {
                throw new InvalidOperationException($"Product with id {id} was not found.");
            }

            _productRepository.Delete(product);
        }
    }
}