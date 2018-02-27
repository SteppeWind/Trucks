using System;
using System.Collections.Generic;
using System.Text;
using Trucks.Common.Data.Infrastructure;
using Trucks.Domain;

namespace Trucks.Data.Repositories
{
    public interface IPointRepository : IEntityRepository<Point>
    {
    }

    public class PointRepository : EntityRepositoryBase<Point>, IPointRepository
    {
        public PointRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}