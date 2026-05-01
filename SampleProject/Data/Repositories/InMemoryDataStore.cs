using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    internal class InMemoryDataStore
    {
        public static List<Product> Products { get; } = new List<Product>();
        public static List<Order> Orders { get; } = new List<Order>();
    }
}
