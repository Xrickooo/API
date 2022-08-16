using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodAPI2;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Data.SQLite.EF6;
using System.Text.Json;
using Meal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MealDB>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

builder.Services.AddDbContext<PhoneDB>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn2")));

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












