using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// db services
builder.Services.AddDbContext<GoPokerDbContext>(opt => opt.
    UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("API")).
    UseLazyLoadingProxies());

// Application services
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

builder.Services.AddScoped<IPlayerCardService, PlayerCardService>();
builder.Services.AddScoped<IPlayerCardRepository, PlayerCardRepository>();

builder.Services.AddScoped<IShoeService, ShoeService>();
builder.Services.AddScoped<IShoeRepository, ShoeRepository>();

builder.Services.AddScoped<IShoeCardService, ShoeCardService>();
builder.Services.AddScoped<IShoeCardRepository, ShoeCardRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
