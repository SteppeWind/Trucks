using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trucks.Web.Models.Customers
{
    public class ListModel
    {
        public IEnumerable<Customer> Customers { get; set; }

        public ListModel()
        {
            Customers = new List<Customer>();
        }

        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string PhoneNumber { get; set; }
            public int TotalOrderCount { get; set; }
            public int IncompleteOrderCount { get; set; }
            public int CompleteOrderCount { get; set; }

            public string FullName() => $"{Name} {Surname}";
        }
    }
}