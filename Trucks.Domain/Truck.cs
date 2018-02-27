using System;
using System.Collections.Generic;
using System.Text;

namespace Trucks.Domain
{
    public class Truck : SizeEntityBase
    {
        public int? OrderId { get; set; }
        public Order Order { get; set; }

        public string Name { get; set; }
        public double FuelConsumption { get; set; }
    }
}