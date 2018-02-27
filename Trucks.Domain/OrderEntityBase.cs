using System;
using System.Collections.Generic;
using System.Text;

namespace Trucks.Domain
{
    public interface IOrderEntityBase : IEntityBase
    {
         Order Order { get; set; }        
    }

    public interface IOptionalOrderEntityBase : IOrderEntityBase
    {
        int? OrderId { get; set; }
    }

    public class OrderEntityBase : EntityBase, IOptionalOrderEntityBase
    {
        public int? OrderId { get; set; }
        public Order Order { get; set; }

        public bool IsUsed => OrderId != null;
    }
}