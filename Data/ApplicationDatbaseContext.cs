using Employees.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees.WebAPI.Data
{
    public class ApplicationDatbaseContext : DbContext
    {
        public ApplicationDatbaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = Guid.Parse("4DD594CA-600B-451E-A8B1-D7A8C7F57CF9"),
                EmployeeName = "David",
                Salary = 10000
            });
        }
    }
}

