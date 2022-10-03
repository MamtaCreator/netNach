using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreConnectedDisconnectedApp.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
