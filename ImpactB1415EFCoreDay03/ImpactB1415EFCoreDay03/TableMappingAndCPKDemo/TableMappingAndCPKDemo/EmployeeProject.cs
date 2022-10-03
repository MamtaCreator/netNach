using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TableMappingAndCPKDemo
{
    public class EmployeeProject
    {
        [Column(Order =0)]
        public int EmployeeId { get; set; }
        [Column(Order =1)]
        public int ProjectId { get; set; }
    }
}
