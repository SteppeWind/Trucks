using System;
using System.Collections.Generic;
using System.Text;

namespace Trucks.Domain
{
    public class Point : EntityBase
    {
        public int CityId { get; set; }
        public City City { get; set; }
        public string Address { get; set; }

        public ICollection<Order> FromPointOrders { get; set; }
        public ICollection<Order> ToPointOrders { get; set; }

        public string DisplayAddress => $"c. {City}, {Address}";

        public Point()
        {
            FromPointOrders = new List<Order>();
            ToPointOrders = new List<Order>();
        }
    }
}