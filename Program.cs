using Employees.WebAPI.Data;
using Employees.WebAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDatbaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")); 
});
builder.Services.AddTransient<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors(options=>options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();
app.UseRouting();

app.MapControllers();

app.Run();
