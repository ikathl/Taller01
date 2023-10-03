﻿using JazaniTaller.Domain.Admins.Repositores;
using JazaniTaller.Infraestructure.Admins.Persistances;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JazaniTaller.Infraestructure.Cores.Contexts
{
    public static class InfraestructureServiceRegistration
    {
        public static IServiceCollection addInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });
            services.AddTransient<IRoleRepository, RoleRepository>();
            return services;
        }
    }
}
