using JazaniTaller.Application.Admins.Dtos.Roles.Mappers;
using JazaniTaller.Infraestructure.Cores.Contexts;
using JazaniTaller.Application.Cores.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//infraestruture
builder.Services.addInfraestructureServices(builder.Configuration);

//aplication
builder.Services.AddApplicationServices();


//AutoMapper 
builder.Services.AddAutoMapper(typeof(RoleMapper));
builder.Services.AddAutoMapper(typeof(RoleMenuPermissionMapper));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
