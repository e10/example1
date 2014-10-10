using DurandalDemo.Model;
using DurandalDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace DurandalDemo
{
    public class IocHelper
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<DataContextModule>();
            builder.RegisterModule<DataAccessLayerModule>();
            builder.RegisterModule<ServicesModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //GlobalHost.DependencyResolver = new Autofac.Integration.SignalR.AutofacDependencyResolver(container);

            return container;
        }
    }
}