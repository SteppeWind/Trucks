using System;
using System.Collections.Generic;
using System.Text;

namespace Trucks.Domain
{
    public class Customer : UserEntityBase
    {
        public ICollection<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}