using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Builder;
using Trucks.Common.Data;
using Trucks.Common.Data.Infrastructure;
using Trucks.Data.Infrastructure;
using Trucks.Data.Repositories;

namespace Trucks.Data
{
    public static class Bootstrapper
    {
        public static void RegisterTypes(ContainerBuilder builder, Func<IRegistrationBuilder<object, object, object>, IRegistrationBuilder<object, object, object>> lifetimeScopeConfigurator)
        {                    
            builder.RegisterType<TrucksDbFactory>().As<IDbFactory>().ApplyDefaultConfiguration(lifetimeScopeConfigurator);
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().ApplyDefaultConfiguration(lifetimeScopeConfigurator);
            builder.RegisterType<DriverRepository>().As<IDriverRepository>().ApplyDefaultConfiguration(lifetimeScopeConfigurator);
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().ApplyDefaultConfiguration(lifetimeScopeConfigurator);
            builder.RegisterType<PointRepository>().As<IPointRepository>().ApplyDefaultConfiguration(lifetimeScopeConfigurator);
            builder.RegisterType<ProductRepository>().As<IProductRepository>().ApplyDefaultConfiguration(lifetimeScopeConfigurator);
            builder.RegisterType<TruckRepository>().As<ITruckRepository>().ApplyDefaultConfiguration(lifetimeScopeConfigurator);
            builder.RegisterType<SettingsRepository>().As<ISettingsRepository>().ApplyDefaultConfiguration(lifetimeScopeConfigurator);
        }        
    }
}