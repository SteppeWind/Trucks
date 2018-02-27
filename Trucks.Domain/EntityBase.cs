using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Trucks.Domain
{
    public interface IEntityBase
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
    }

    public class EntityBase : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }        
    }

    public static class EntityExtensions
    {
        public static bool IsNew(this IEntityBase self)
        {
            return self.Id == 0;
        }
    }
}