using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationships.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public EmployeeAddress EmployeeAddress { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        //public IEnumerable<Project> EmployeeProjects { get; set; }
        public IEnumerable<EmployeesInProject> EmployeesInProject { get; set; }
    }
}
