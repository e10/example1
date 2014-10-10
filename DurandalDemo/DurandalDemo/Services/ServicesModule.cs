using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DurandalDemo.Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProspectService>().As<IProspectService>();
        }
    }
}