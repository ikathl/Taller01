using Autofac;
using System.Reflection;

namespace JazaniTaller.Application.Cores.Contexts
{

    public class ApplicationAutofacModule : Autofac.Module
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
