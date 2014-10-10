using Autofac;
using DurandalDemo.DAL;
using System.Data.Entity;

namespace DurandalDemo.Model
{
    public class DataContextModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProspectContext>().As<IProspectContext>().As<DbContext>().As<ProspectContext>().InstancePerRequest();
            builder.RegisterType<ProspectContext>().As<IProspectContextMany>();

            Database.SetInitializer(new NullDatabaseInitializer<ProspectContext>());
        }
    }
}