using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentNegotiationDemo.Models
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
    }
}
