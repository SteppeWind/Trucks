using System;
using System.Collections.Generic;
using System.Text;

namespace Trucks.Domain
{
    public class Settings : EntityBase
    {
        public double PricePerKilometr { get; set; }
        public bool AutogenerationPrice { get; set; }
    }
}