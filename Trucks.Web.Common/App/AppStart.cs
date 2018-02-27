using System;
using System.Reflection;
using System.Web.Mvc;
using System.Web.WebPages;
using Autofac;
using Autofac.Builder;
using Autofac.Integration.Mvc;
using Trucks.Common;
using Trucks.Common.Data;

namespace Trucks.Web.Common.App
{
    public class AppStart
    {
        public Func<IRegistrationBuilder<object, object, object>, IRegistrationBuilder<object, object, object>> LifetimeScopeConfigurator { get; }

        public AppStart(Func<IRegistrationBuilder<object, object, object>, IRegistrationBuilder<object, object, object>> lifetimeScopeConfigurator = null)
        {
            LifetimeScopeConfigurator = lifetimeScopeConfigurator ?? (registrationBuilder => registrationBuilder.InstancePerRequest());          
        }

        public virtual void Run()
        {
            var builder = new ContainerBuilder();
            RegisterTypes(builder);

            builder.RegisterModule(new AutofacWebTypesModule());

            RegisterRoutes();
            RegisterBundles();

            builder.RegisterSource(new ViewRegistrationSource());

            var container = builder.Build();
            SetDependencyResolver(container);
        }

        public virtual void RegisterTypes(ContainerBuilder builder)
        {
            Bootstrapper.RegisterTypes(builder, LifetimeScopeConfigurator);
        }

        protected virtual void RegisterBundles()
        {
        }

        protected virtual void RegisterRoutes()
        {
        }

        protected virtual void SetDependencyResolver(IContainer container)
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            ServiceLocator.Register(serviceType => DependencyResolver.Current.GetService(serviceType));
        }
    }

    public static class RegistrationBuilderExtensions
    {
        public static void ApplyDefaultPerRequestConfiguration(this IRegistrationBuilder<object, object, object> registrationBuilder, AppStart config, bool dontAllowCircularDependencies = false)
        {
            registrationBuilder.ApplyDefaultConfiguration(config.LifetimeScopeConfigurator, dontAllowCircularDependencies);
        }
    }
}