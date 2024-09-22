using Employees.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employees.WebAPI.Repository
{
    public interface IEmployeeService
    {
        public  Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees();
        public Task<Employee> GetEmployeeById(Guid id);
        public Task<Employee> AddEmployee(Employee employee);
        public  Task<bool> DeleteEmployee(Employee employee);
        public Task<bool> UpdateEmployee(Guid id, Employee employee);
    }
}
