using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trucks.Common.Data.Infrastructure;

namespace Trucks.Data.Infrastructure
{
    public class TrucksDbFactory : DbFactoryBase
    {
        protected override IDbContext Create()
        {
            return new DbContextAdapter(new TrucksDbContext());
        }
    }
}