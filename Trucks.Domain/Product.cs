using System;
using System.Collections.Generic;
using System.Text;

namespace Trucks.Domain
{
    public class Product : SizeEntityBase
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}