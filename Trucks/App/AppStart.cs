using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Builder;
using Autofac.Integration.Mvc;

[assembly: PreApplicationStartMethod(typeof(Trucks.Web.App.AppStart), nameof(Trucks.Web.App.AppStart.Start))]
namespace Trucks.Web.App
{    
    public class AppStart : Common.App.AppStart
    {
        public static void Start()
        {
            HtmlHelper.ClientValidationEnabled = true;
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;
            new AppStart().Run();
        }

        public AppStart(Func<IRegistrationBuilder<object, object, object>, IRegistrationBuilder<object, object, object>> lifetimeScopeConfigurator = null) : base(lifetimeScopeConfigurator)
        {
        }

        public override void RegisterTypes(ContainerBuilder builder)
        {
            base.RegisterTypes(builder);

            Data.Bootstrapper.RegisterTypes(builder, LifetimeScopeConfigurator);
            Services.Bootstrapper.RegisterTypes(builder, LifetimeScopeConfigurator);

            builder.RegisterControllers(typeof(AppStart).Assembly).PropertiesAutowired();
        }

        protected override void RegisterBundles()
        {
            base.RegisterBundles();
            BundleConfig.RegisterBundles();
        }

        protected override void RegisterRoutes()
        {
            base.RegisterRoutes();
            RouteConfig.RegisterRoutes();
        }
    }
}