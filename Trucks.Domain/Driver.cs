using System;
using System.Collections.Generic;
using System.Text;

namespace Trucks.Domain
{   
    public class Driver : UserEntityBase, IOptionalOrderEntityBase
    {
        public double Experince { get; set; }
        public double Salary { get; set; }

        public Order Order { get; set; }
        public int? OrderId { get; set; }
    }
}