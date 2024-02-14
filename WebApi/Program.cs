using Application.Interfaces;
using Application.Services;
using Application.Validators;
using Domain.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Persistance.Context;
using Persistance.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<OnionContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
// Add services to the container.
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
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
