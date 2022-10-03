using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationships.Models
{
    public class EmployeesInProject
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}
