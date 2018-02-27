using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trucks.Common.Data.Infrastructure;
using Trucks.Common.Exceptions;
using Trucks.Data.Repositories;
using Trucks.Domain;
using Trucks.Services.Exceptions;

namespace Trucks.Services
{
    public interface ICustomerService : IUserService
    {
        void Save(Customer customer);
        void Delete(int id);
    }

    public class CustomerService : ICustomerService
    {
        public IOrderService OrderService { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        public void Save(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            if (Exist(customer.PhoneNumber))
                throw new UserAlreadyExistException(customer);

            CustomerRepository.Save(customer);
            UnitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var customer = CustomerRepository.GetById(id);

            if (customer == null)
                throw new BusinessException($"Customer by {id} not found");

            var orders = customer.Orders.ToArray();

            foreach (var order in orders)
            {
                OrderService.Delete(order.Id);
            }

            CustomerRepository.Delete(customer);
            UnitOfWork.Commit();
        }

        public bool Exist(string phoneNumber, bool throwExceptionIfNotFound = false)
        {
            var exist = CustomerRepository.Exist(phoneNumber);

            if (throwExceptionIfNotFound && !exist)
                throw new UserNotFoundException(phoneNumber);

            return exist;
        }
    }
}