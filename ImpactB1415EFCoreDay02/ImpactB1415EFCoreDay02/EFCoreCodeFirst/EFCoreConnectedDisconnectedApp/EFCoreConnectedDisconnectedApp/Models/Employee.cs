using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreConnectedDisconnectedApp.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }

        public virtual Dept Department { get; set; }
    }
}
