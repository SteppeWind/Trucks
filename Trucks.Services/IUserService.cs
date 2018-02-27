using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trucks.Services
{
    public interface IUserService
    {
        bool Exist(string phoneNumber, bool throwExceptionIfNotFound = false);
    }
}