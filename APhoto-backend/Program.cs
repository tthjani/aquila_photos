using APhoto_backend.Data;
using APhoto_backend.Models;
using APhoto_backend.Services.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<APhotosContext>(options =>
    options.UseSqlServer("Server=localhost,1436;Database=aquila_photos_db;User Id=sa;Password=aquilaPhotos(!)Password;Encrypt=false;"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IAcceptedOrdersRepository, AcceptedOrdersRepository>();
builder.Services.AddScoped<IDeclinedOrdersReporitory, DeclinedOrdersRepository>();
builder.Services.AddScoped<IFinishedOrdersRepository, FinishedOrdersRepository>();

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