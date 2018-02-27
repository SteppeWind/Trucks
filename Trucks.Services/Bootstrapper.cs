using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Builder;
using Trucks.Common.Data;

namespace Trucks.Services
{
    public static class Bootstrapper
    {
        public static void RegisterTypes(ContainerBuilder builder, Func<IRegistrationBuilder<object, object, object>, IRegistrationBuilder<object, object, object>> lifetimeScopeConfigurator)
        {
            builder.RegisterType<CustomerService>().As<ICustomerService>().ApplyDefaultConfiguration(lifetimeScopeConfigurator);
        }
    }
}