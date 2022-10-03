using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDbFirst.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public override string ToString()
        {
            return string.Format("Employee Id:{0}, First Name:{1}, Last Name:{2}, Salary:{3}, Department ID:{4}",
                EmployeeId, FirstName, LastName, Salary, DepartmentId);
        }
    }
}
