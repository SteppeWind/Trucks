using System;
using System.Collections.Generic;
using System.Text;
using Trucks.Common.Data.Infrastructure;
using Trucks.Domain;

namespace Trucks.Data.Repositories
{
    public interface ITruckRepository : ISizeEntityRepository<Truck>
    {
    }

    public class TruckRepository : SizeEntityRepository<Truck>, ITruckRepository
    {
        public TruckRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}