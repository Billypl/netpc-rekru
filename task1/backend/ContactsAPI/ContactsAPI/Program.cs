using ContactsAPI.Database;
using ContactsAPI.Repositories;
using ContactsAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
;
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