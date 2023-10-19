using Autofac;
using Autofac.Extensions.DependencyInjection;
using JazaniTaller.Api.Filters;
using JazaniTaller.Api.Middleware;
using JazaniTaller.Application.Cores.Contexts;
using JazaniTaller.Infraestructure.Cores.Contexts;
using Serilog;
using Serilog.Events;
using JazaniTaller.Core.Securities.Services;
using Jazani.Core.Securities.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


var logger = new LoggerConfiguration()
    .WriteTo.Console(LogEventLevel.Information)
    .WriteTo.File(
        ".." + Path.DirectorySeparatorChar + "loggapi.log",
        LogEventLevel.Warning,
        rollingInterval: RollingInterval.Day
    )
    .CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.AddControllers(Options =>
{
    Options.Filters.Add(new ValidationFilter());

    AuthorizationPolicy authorizationPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    Options.Filters.Add(new AuthorizeFilter());
});
//Route options

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//passwordhasher
builder.Services.Configure<PasswordHasherOptions>(options =>
{
    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
});

// ISecurityService
builder.Services.AddTransient<ISecurityService, SecurityService>();

//JWT
string jwtSecretKey = builder.Configuration.GetSection("Security:JwtSecrectKey").Get<string>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    byte[] key = Encoding.ASCII.GetBytes(jwtSecretKey);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateLifetime = true,
        ValidIssuer = "",
        ValidAudience = "",
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true
    };
});

// AuthorizeOperationFilter
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<AuthorizeOperationFilter>();
    string schemeName = "Bearer";
    options.AddSecurityDefinition(schemeName, new OpenApiSecurityScheme()
    {
        Name = schemeName,
        BearerFormat = "JWT",
        Scheme = "bearer",
        Description = "Add token.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http
    });
});

//infraestruture
builder.Services.addInfraestructureServices(builder.Configuration);

//aplication
builder.Services.AddApplicationServices();


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterModule(new InfraestructureAutofacModule());
        options.RegisterModule(new ApplicationAutofacModule());
    });

builder.Services.AddTransient<ExceptionMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
{
    options.AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyOrigin()
    .Build();
});

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
