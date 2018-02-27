using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trucks.Common.Data.Infrastructure;
using Trucks.Data.Repositories;
using Trucks.Domain;

namespace Trucks.Services
{
    public interface IOrderService
    {
        void Save(Order order);
        void Delete(int id);
    }

    public class OrderService : IOrderService 
    {
        public IOrderRepository OrderRepository { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        public void Save(Order order)
        {

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}