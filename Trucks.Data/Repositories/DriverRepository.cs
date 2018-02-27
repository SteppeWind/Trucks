using System;
using System.Collections.Generic;
using System.Text;
using Trucks.Common.Data.Infrastructure;
using Trucks.Domain;

namespace Trucks.Data.Repositories
{
    public interface IDriverRepository : IUserRepository<Driver>
    {        
    }

    public class DriverRepository : UserRepository<Driver>, IDriverRepository
    {
        public DriverRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}