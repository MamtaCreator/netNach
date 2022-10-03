using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidationDependencyInjection.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        static List<Employee> employees = null;

        static EmployeeRepository()
        {
            employees = new List<Employee>()
            {
                new Employee{EmployeeId = 1001, Name = "Sachin Tendulkar", Salary = 50000},
                new Employee{EmployeeId = 1002, Name = "Pusarla Sindhu", Salary = 50000}
            };
        }
        public Employee AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return employee;
        }

        public int DeleteEmployee(int employeeId)
        {
            Employee existingEmployee = employees.FirstOrDefault(emp => emp.EmployeeId == employeeId);
            if (existingEmployee != null)
            {
                employees.Remove(existingEmployee);
            }
            return employeeId;
        }

        public Employee GetEmployee(int employeeId)
        {
            Employee employee = employees.FirstOrDefault(emp => emp.EmployeeId == employeeId);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee UpdateEmployee(int employeeId, Employee employee)
        {
            Employee existingEmployee = employees.FirstOrDefault(emp => emp.EmployeeId == employeeId);
            if(existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Salary = employee.Salary;
            }
            return employee;
        }
    }
}
