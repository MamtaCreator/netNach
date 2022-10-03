using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpStatusCodesDemo.Models
{
    public class EmployeeOperations:IEmployee
    {
        private static List<Employee> employees;

        static EmployeeOperations()
        {
            employees = new List<Employee>
            {
                new Employee{EmployeeId = 101, Name = "Sachin Tendulkar", Salary = 5000 },
                new Employee{EmployeeId = 102, Name = "P V Sindhu", Salary = 5000  }
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

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return employees.FirstOrDefault(emp => emp.EmployeeId == employeeId);
        }

        public Employee UpdateEmployee(int employeeId, Employee employee)
        {
            Employee existingEmployee = employees.FirstOrDefault(emp => emp.EmployeeId == employeeId);
            if(existingEmployee!=null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Salary = employee.Salary;
            }
            return employee;
        }
    }
}
