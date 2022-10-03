using System;
using System.Collections.Generic;
using System.Text;

namespace TableMappingAndCPKDemo
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
