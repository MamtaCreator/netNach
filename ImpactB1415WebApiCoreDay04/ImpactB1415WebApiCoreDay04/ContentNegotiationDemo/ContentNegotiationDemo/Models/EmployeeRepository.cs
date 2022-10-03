using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentNegotiationDemo.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        static List<Employee> employees = null;

        static EmployeeRepository()
        {
            employees = new List<Employee>()
            {
                new Employee(){EmployeeId=1001,FirstName="Sachin",LastName="Tendulkar",Salary=5000},
                new Employee(){EmployeeId=1002,FirstName="Pusarla",LastName="Sindhu",Salary=5000}
            };
        }
        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
