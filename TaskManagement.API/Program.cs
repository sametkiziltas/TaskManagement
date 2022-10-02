using System.ComponentModel;
using System.Text.Json;
using CommentManagement.API.ServiceLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManagement.API;
using TaskManagement.API.DataLayer;
using TaskManagement.API.DataLayer.Entities;
using TaskManagement.API.DataLayer.Repositories;
using TaskManagement.API.Filters;
using TaskManagement.API.ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ITaskRepository, TaskRepository>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<ITaskService, TaskService>();

builder.Services.AddTransient<ICommentService, CommentService>();

var connectionString = ConnStr.Get();

builder.Services.AddDbContext<TMContext>(options =>
{
    options.UseNpgsql(connectionString,o=> o.SetPostgresVersion(9,6));
});

builder.Services.AddMvcCore(options => options.Filters.Add(typeof(GlobalExceptionFilter)))
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        // options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
    });




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
