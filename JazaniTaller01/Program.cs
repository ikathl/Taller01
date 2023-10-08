using Autofac;
using Autofac.Extensions.DependencyInjection;
using JazaniTaller.Api.Filters;
using JazaniTaller.Api.Middleware;
using JazaniTaller.Application.Cores.Contexts;
using JazaniTaller.Infraestructure.Cores.Contexts;
using Serilog;
using Serilog.Events;

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
});
//Route options

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
