using Microsoft.EntityFrameworkCore;
using ShopProject.Application.Extensions;
using ShopProject.Infrustructure.Context;
using ShopProject.Infrustructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add Db Context
builder.Services.AddDbContext<ShopProjectDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Add customer services (repositories, services, packages, UnitOfWork, CQRS)
builder.Services.AddCustomServices();
builder.Services.AddApplicationServices();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
