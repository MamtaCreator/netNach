using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidationDependencyInjection.Models
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(int employeeId, Employee employee);
        int DeleteEmployee(int employeeId);
    }
}
