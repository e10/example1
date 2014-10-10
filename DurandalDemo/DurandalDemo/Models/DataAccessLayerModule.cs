using Autofac;
using DurandalDemo.DAL;

namespace DurandalDemo.Model
{
    public class DataAccessLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProspectRepository>().As<IProspectRepository>();
        }
    }
}
