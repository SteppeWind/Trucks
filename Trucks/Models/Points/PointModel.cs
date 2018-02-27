using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trucks.Web.Models.Points
{
    public class PointModel
    {
        public int Id { get; set; }        
        public string Address { get; set; }
        public CityModel City { get; set; }

        public class CityModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}