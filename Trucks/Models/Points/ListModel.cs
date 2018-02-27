using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trucks.Web.Models.Points
{
    public class ListModel
    {
        public IEnumerable<PointModel> Points { get; set; }

        public ListModel()
        {
            Points = Enumerable.Empty<PointModel>();
        }        
    }
}