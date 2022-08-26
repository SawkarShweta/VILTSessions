using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APIEntityFramework.Data;
using APIEntityFramework.Controllers;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<APIEntityFrameworkContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIEntityFrameworkContext") ?? throw new InvalidOperationException("Connection string 'APIEntityFrameworkContext' not found.")));

// Add services to the container.

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

app.MapStudentEndpoints();

app.Run();
