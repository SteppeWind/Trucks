using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trucks.Services.Exceptions
{
    public class UserNotFoundException : Exception
    {       
        public UserNotFoundException(string phoneNumber) : base($"User not found by phone \"{phoneNumber}\"")
        {
        }
    }
}