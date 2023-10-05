﻿using JazaniTaller.Application.Admins.Services;
using JazaniTaller.Application.Admins.Services.Implementations;
using JazaniTaller.Domain.Admins.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JazaniTaller.Application.Cores.Contexts
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddTransient<IRoleService, RoleService>();
            //services.AddTransient<IRoleMenuPermissionService, RoleMenuPermissionService>();

            return services;
        }
    }
}
