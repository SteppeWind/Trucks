using System;
using System.Collections.Generic;
using System.Text;
using Trucks.Common.Data.Infrastructure;
using Trucks.Domain;

namespace Trucks.Data.Repositories
{
    public interface IProductRepository : ISizeEntityRepository<Product>
    {
    }

    public class ProductRepository : SizeEntityRepository<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}