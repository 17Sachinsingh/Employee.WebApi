using Employees.WebAPI.Data;
using Employees.WebAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employees.WebAPI.Repository
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDatbaseContext _context;
        public EmployeeService(ApplicationDatbaseContext context)
        {
            _context= context;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
             return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(Guid id)
        {
            return await _context.Employees.FindAsync(id);

        }
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            
            
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            
            
        }
        public async Task<bool> UpdateEmployee(Guid id, Employee employee)
        {
            var existingEmployee = await GetEmployeeById(id);
            if (existingEmployee == null)
            {
                return false;
            }
            else { 
            existingEmployee.EmployeeName = employee.EmployeeName;
            existingEmployee.Salary = employee.Salary;

            await _context.SaveChangesAsync();
            return true;
            }
        }
    }
}
