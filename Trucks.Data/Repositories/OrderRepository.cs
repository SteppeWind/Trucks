using System;
using System.Collections.Generic;
using System.Text;
using Trucks.Common.Data.Infrastructure;
using Trucks.Domain;

namespace Trucks.Data.Repositories
{
    public interface IOrderRepository : IEntityRepository<Order>
    {
    }

    public class OrderRepository : EntityRepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}