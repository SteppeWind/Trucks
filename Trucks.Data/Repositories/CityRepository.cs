using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trucks.Common.Data.Infrastructure;
using Trucks.Domain;

namespace Trucks.Data.Repositories
{
    public interface ICityRepository : IEntityRepository<City>
    {
    }

    public class CityRepository : EntityRepositoryBase<City>, ICityRepository
    {
        public CityRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}