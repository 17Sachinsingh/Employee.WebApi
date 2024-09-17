using System.ComponentModel.DataAnnotations;

namespace Employees.WebAPI.Models
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string EmployeeName { get; set; } 
        [Required(ErrorMessage = "Salary is required")]
        public int Salary { get; set; }
    }
}
