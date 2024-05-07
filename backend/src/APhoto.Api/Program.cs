using APhoto.Api.Services;
using APhoto.Common.Repositories;
using APhoto.Data;
using APhoto.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using APhoto.Api.CustomConfiguration;
using Serilog.Configuration;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    EnvironmentName = "Development",
    ContentRootPath = AppContext.BaseDirectory
});

builder.Host.SetCustomHostConfiguration()
    .UseWindowsService()
    .ConfigureSerilog(services => services.AddSingleton<ILoggerSettings, SerilogConfiguration>());

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("APhotosContext");
builder.Services.AddDbContext<APhotosContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddScoped<IAbstractRepository<Order>, OrdersRepository>();
builder.Services.AddScoped<IAbstractRepository<Holiday>, HolidayRepository>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IHolidayService, HolidayService>();

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