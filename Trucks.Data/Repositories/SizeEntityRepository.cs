using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trucks.Common.Data.Infrastructure;
using Trucks.Domain;

namespace Trucks.Data.Repositories
{
    public interface ISizeEntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity :class, ISizeEntityBase
    {
        IQueryable<TEntity> GetByVolume(double volume);
    }

    public abstract class SizeEntityRepository<TEntity> : EntityRepositoryBase<TEntity>, ISizeEntityRepository<TEntity> where TEntity : class, ISizeEntityBase
    {
        protected SizeEntityRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<TEntity> GetByVolume(double volume)
        {
            return GetMany(s => s.Volume == volume);
        }        
    }
}