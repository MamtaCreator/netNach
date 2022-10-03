using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpStatusCodesDemo.Models
{
    public interface IEmployee
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int employeeId);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(int employeeId, Employee employee);
        int DeleteEmployee(int employeeId);
    }
}
