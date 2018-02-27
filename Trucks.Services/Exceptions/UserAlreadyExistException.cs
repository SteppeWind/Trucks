using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trucks.Domain;

namespace Trucks.Services.Exceptions
{
    public class UserAlreadyExistException : Exception
    {
        public UserEntityBase User { get; }

        public UserAlreadyExistException(string message) : base(message)
        {
        }

        public UserAlreadyExistException(UserEntityBase user) : base($"User with phone {user.PhoneNumber} already exist.")
        {
            User = user;
        }
    }
}
