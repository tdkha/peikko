using PeikkoDesigner.Models;
using PeikkoDesigner.Services;
using PeikkoDesigner.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------------------------------
// SERVICES CONFIGURATION
// ----------------------------------------------------
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IComputeService, ComputeService>();

// ----------------------------------------------------
// DATBASE CONFIGURATION
// ----------------------------------------------------
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();
