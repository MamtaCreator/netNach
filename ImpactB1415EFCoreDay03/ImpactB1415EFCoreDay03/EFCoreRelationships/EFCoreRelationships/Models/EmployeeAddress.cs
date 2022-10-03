using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationships.Models
{
    public class EmployeeAddress
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Employee Employee { get; set; }
    }
}
