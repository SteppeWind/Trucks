using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Trucks.Common.Data.Infrastructure;
using Trucks.Common.Extensions;
using Trucks.Data.Infrastructure;
using Trucks.Domain;

namespace Trucks.Data.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : IEntityBase
    {
        void Save(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(int id);
        TResult GetById<TResult>(int id, Expression<Func<TEntity, TResult>> selector);
        IQueryable<TEntity> GetAll();
        IQueryable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector);
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        IQueryable<TResult> GetMany<TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TResult>> selector);
        bool Exist(int id);
    }

    public class EntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntityBase
    {
        protected IDbContext DataContext { get; }
        protected DbSet<TEntity> Entities { get; }

        public EntityRepositoryBase(IDbFactory dbFactory)
        {
            DataContext = dbFactory.Get();
            Entities = DataContext.Set<TEntity>();
        }

        public void Save(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.IsNew())
                Add(entity);
            else
                Update(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
           
            Entities.Remove(entity);
        }

        public TEntity GetById(int id)
        {
            return Entities.FirstOrDefault(e => e.Id == id);
        }

        public TResult GetById<TResult>(int id, Expression<Func<TEntity, TResult>> selector)
        {
            var result = GetMany(e => e.Id == id, selector).Take(1).ToArray();

            return result.FirstOrDefault();
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }

        public IQueryable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return GetAll().Select(selector);
        }

        public IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return GetAll().Where(where);
        }

        public IQueryable<TResult> GetMany<TResult>(Expression<Func<TEntity, bool>> @where, Expression<Func<TEntity, TResult>> selector)
        {
            return GetAll().Where(where).Select(selector);
        }

        public bool Exist(int id)
        {
            return Entities.Any(e => e.Id == id);
        }

        protected virtual void Update(TEntity entity)
        {
            var entityState = DataContext.GetEntityState(entity);

            if (entityState == EntityState.Detached)
            {
                entityState = EntityState.Modified;
                DataContext.AttachEntity(entity, entityState);
            }            
        }

        protected virtual void Add(TEntity entity)
        {
            if (entity.CreatedAt.IsEmpty())
                entity.CreatedAt = DateTime.UtcNow;

            Entities.Add(entity);
        }
    }
}