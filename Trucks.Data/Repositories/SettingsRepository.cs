using System;
using System.Collections.Generic;
using System.Text;
using Trucks.Common.Data.Infrastructure;
using Trucks.Domain;

namespace Trucks.Data.Repositories
{
    public interface ISettingsRepository : IEntityRepository<Settings>
    {
    }

    public class SettingsRepository : EntityRepositoryBase<Settings>, ISettingsRepository
    {
        public SettingsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}