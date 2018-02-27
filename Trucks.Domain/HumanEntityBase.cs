using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Trucks.Domain
{
    public interface IUserEntityBase : IEntityBase
    {
        string Name { get; set; }
        string Surname { get; set; }
        string PhoneNumber { get; set; }
    }

    public abstract class UserEntityBase : EntityBase, IUserEntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }
}