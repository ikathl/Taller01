using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JazaniTaller.Application.Cores.Contexts
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
