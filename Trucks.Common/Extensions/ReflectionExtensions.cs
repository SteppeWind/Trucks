using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Trucks.Common.Extensions
{
    public static class ReflectionExtensions
    {
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> Storage = new ConcurrentDictionary<Type, PropertyInfo[]>();

        public static PropertyInfo GetPublicInstanceProperty(this Type self, string name)
        {
            return self.GetPublicInstanceProperties().FirstOrDefault(p => p.Name == name);
        }

        public static IEnumerable<PropertyInfo> GetPublicInstanceProperties(this Type self)
        {
            if (self == null)
                return Enumerable.Empty<PropertyInfo>();

            return Storage.GetOrAdd(self, self.GetProperties(BindingFlags.Public | BindingFlags.Instance));
        }

        public static object GetDefault(this Type self)
        {
            if (self == null)
                return null;

            return self.IsValueType ? Activator.CreateInstance(self) : null;
        }
    }
}