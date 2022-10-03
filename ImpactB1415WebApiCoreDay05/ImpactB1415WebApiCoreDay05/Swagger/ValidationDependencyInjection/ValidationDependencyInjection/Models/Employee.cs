using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ValidationDependencyInjection.Models
{
    public class Employee
    {
        [Range(1001, Int32.MaxValue, ErrorMessage ="Employee Id is mandatory and should be greater than 1000")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="Name is mandatory")]
        [StringLength(30,MinimumLength =5,ErrorMessage ="Employee name should be between 5 to 30 characters")]
        public string Name { get; set; }
        [Range(30000,Double.MaxValue, ErrorMessage = "Salary is required and should be 30000 or more")]
        public double Salary { get; set; }
    }
}
