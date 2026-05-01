using BusinessEntities;
using System;
using System.Collections.Generic;

public interface IProductRepository
{
    Product Get(Guid id);
    IEnumerable<Product> GetAll();
    IEnumerable<Product> GetList(
           string name = null,
           decimal? minPrice = null,
           decimal? maxPrice = null);

    void Save(Product product);

    void Delete(Product product);
    void Delete(Guid id);
}