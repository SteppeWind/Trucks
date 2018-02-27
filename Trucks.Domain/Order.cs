using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Trucks.Domain
{
    public class Order : EntityBase
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? SettingsId { get; set; }
        public Settings Settings { get; set; }

        public int FromPointId { get; set; }
        public Point FromPoint { get; set; }

        public int ToPointId { get; set; }
        public Point ToPoint { get; set; }

        public int TruckId { get; set; }
        public Truck Truck { get; set; }
        
        public ICollection<Product> Products { get; set; }
        public ICollection<Driver> Drivers { get; set; }

        public double Cost { get; set; }
        public Status Status { get; set; }

        public DateTime? CompletionAt { get; set; }

        public Order()
        {
            Products = new List<Product>();
            Drivers = new List<Driver>();
        }
    }

    public enum Status
    {
        Complete = 1,
        Incomplete = 2
    }
}