using ContactsAPI.Database;
using ContactsAPI.Entities;
using ContactsAPI.Repositories;
using ContactsAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ContactsDbContext>();
builder.Services.AddScoped<ContactsDbSeeder>();

builder.Services.AddScoped<IContactService, ContactsService>();
builder.Services.AddScoped<IContactsRepository, ContactsRepository>();

var app = builder.Build();
var seeder = app.Services.CreateScope().ServiceProvider.GetRequiredService<ContactsDbSeeder>();
seeder.Seed();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
