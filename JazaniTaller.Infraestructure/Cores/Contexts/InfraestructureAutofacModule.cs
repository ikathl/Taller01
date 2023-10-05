using Autofac;
using System.Reflection;


namespace JazaniTaller.Infraestructure.Cores.Contexts
{
    public class InfraestructureAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
