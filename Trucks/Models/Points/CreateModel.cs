using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trucks.Web.Models.Points
{
    public class CreateModel
    {
        public int CityId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}