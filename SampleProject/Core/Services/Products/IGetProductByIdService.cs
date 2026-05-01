using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface IGetProductByIdService
    {
        Product Get(Guid id);
    }
}
