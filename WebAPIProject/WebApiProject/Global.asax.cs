using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebApiProject.Interfaces;
using WebApiProject.Services;

namespace WebApiProject
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //area registration for help page
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Set Autofac as IoC container
            // initializing Autofac container
            var builder = new ContainerBuilder();

            //register the WebAPI controllers and service classes for DI
            builder.RegisterType<SumNumbersService>().As<ISumNumbers>();
            builder.RegisterType<LoadStringsService>().As<ILoadStrings>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //build Autofac and set the dependency resolver
            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
