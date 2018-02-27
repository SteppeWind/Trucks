using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Trucks.Common.Extensions
{
    public static class StringExtensions
    {
        public static string ToJson(this object self)
        {
            return JsonConvert.SerializeObject(self);
        }

        public static bool IsEmpty(this string self)
        {
            return string.IsNullOrEmpty(self);
        }

        public static bool EqualsIgnoringCase(this string self, string value)
        {
            if (self == null)
                return value == null;

            return self.Equals(value, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}