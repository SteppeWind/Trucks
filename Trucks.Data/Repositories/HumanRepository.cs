using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trucks.Common.Data.Infrastructure;
using Trucks.Domain;

namespace Trucks.Data.Repositories
{
    public interface IUserRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IUserEntityBase
    {
        IQueryable<TEntity> GetByName(string name);
        IQueryable<TEntity> GetBySurname(string surname);
        IQueryable<TEntity> GetByNameOrSurname(string search);
        bool Exist(string phoneNumber);
        TEntity GetByPhoneNumber(string phoneNumber);
    }

    public abstract class UserRepository<TEntity> : EntityRepositoryBase<TEntity>, IUserRepository<TEntity> where TEntity : class, IUserEntityBase
    {
        protected UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<TEntity> GetByName(string name)
        {
            return GetMany(h => h.Name.ToLower().Contains(name.ToLower()));
        }

        public IQueryable<TEntity> GetBySurname(string surname)
        {
            return GetMany(h => h.Surname.ToLower().Contains(surname.ToLower()));
        }

        public IQueryable<TEntity> GetByNameOrSurname(string search)
        {
            return GetMany(h => h.Name.ToLower().Contains(search.ToLower()) || h.Surname.ToLower().Contains(search.ToLower()));
        }

        public bool Exist(string phoneNumber)
        {
            return GetByPhoneNumber(phoneNumber) != null;
        }

        public TEntity GetByPhoneNumber(string phoneNumber)
        {
            return GetAll().SingleOrDefault(h => h.PhoneNumber.ToLower().Equals(phoneNumber.ToLower()));
        }
    }
}