using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace Trucks.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static Dictionary<string, object> ToDictionary(this object self)
        {
            return self.ToDictionary<object>();
        }

        public static Dictionary<string, TValue> ToDictionary<TValue>(this object self)
        {
            switch (self)
            {
                case null:
                    return new Dictionary<string, TValue>();

                case Dictionary<string, TValue> values:
                    return values;
            }

            return self.GetType().GetPublicInstanceProperties()
                .Where(p => p.GetMethod != null && p.GetIndexParameters().Length == 0)
                .ToDictionary(p => p.Name, p => (TValue)p.GetValue(self));
        }

        public static TCastType To<TCastType>(this object self)
        {
            Mapper.Initialize(cfg => cfg.CreateMap(self.GetType(), typeof(TCastType)));
            var castResult = Mapper.Map(self, self.GetType(), typeof(TCastType));

            return (TCastType)castResult;
        }
    }
}