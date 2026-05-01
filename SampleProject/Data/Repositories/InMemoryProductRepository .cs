using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        public Product Get(Guid id)
        {
            return InMemoryDataStore.Products
                .FirstOrDefault(product => product.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return InMemoryDataStore.Products;
        }

        public IEnumerable<Product> GetList(
            string name = null,
            decimal? minPrice = null,
            decimal? maxPrice = null)
        {
            var query = InMemoryDataStore.Products.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(product =>
                    product.Name != null &&
                    product.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (minPrice.HasValue)
            {
                query = query.Where(product => product.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(product => product.Price <= maxPrice.Value);
            }

            return query.ToList();
        }

        public void Save(Product product)
        {
            var existingProduct = Get(product.Id);

            if (existingProduct == null)
            {
                InMemoryDataStore.Products.Add(product);
            }

            // If the product already exists, do nothing.
            // The existing product object has already been updated in memory.
        }

        public void Delete(Product product)
        {
            if (product == null)
            {
                return;
            }

            InMemoryDataStore.Products.Remove(product);
        }

        public void Delete(Guid id)
        {
            var product = Get(id);

            if (product != null)
            {
                InMemoryDataStore.Products.Remove(product);
            }
        }
    }
}