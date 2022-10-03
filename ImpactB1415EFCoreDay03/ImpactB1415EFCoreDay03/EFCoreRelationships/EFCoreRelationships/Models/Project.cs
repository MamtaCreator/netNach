using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationships.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        //public IEnumerable<Employee> ProjectEmployees { get; set; }
        public IEnumerable<EmployeesInProject> EmployeesInProject { get; set; }
    }
}
