using System;
using System.Collections.Generic;
using System.Text;

namespace Trucks.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsEmpty(this DateTime self)
        {
            return self == DateTime.MinValue;
        }
    }
}