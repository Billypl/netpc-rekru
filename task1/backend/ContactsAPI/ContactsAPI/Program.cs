using ContactsAPI.Database;
using ContactsAPI.Middleware;
using ContactsAPI.Repositories;
using ContactsAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
;
builder.Services.AddDbContext<ContactsDbContext>();
builder.Services.AddScoped<ContactsDbSeeder>();

builder.Services.AddScoped<ErrorHandlerMiddleware>();

builder.Services.AddScoped<IContactService, ContactsService>();
builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();

var app = builder.Build();
var seeder = app.Services.CreateScope().ServiceProvider.GetRequiredService<ContactsDbSeeder>();
seeder.Seed();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();