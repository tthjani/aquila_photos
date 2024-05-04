using APhoto.Common.Repositories;
using APhoto.Data;
using APhoto.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("APhotosContext");
builder.Services.AddDbContext<APhotosContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IAbstractRepository<Order>, OrdersRepository>();
builder.Services.AddScoped<IAbstractRepository<AcceptedOrder>, AcceptedOrdersRepository>();
builder.Services.AddScoped<IAbstractRepository<DeclinedOrder>, DeclinedOrdersRepository>();
builder.Services.AddScoped<IAbstractRepository<FinishedOrder>, FinishedOrdersRepository>();

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