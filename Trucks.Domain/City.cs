using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trucks.Domain
{
    public class City : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Point> Points { get; set; }

        public override string ToString() => Name;

        public City()
        {
            Points = new List<Point>();
        }
    }
}