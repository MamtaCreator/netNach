using LinqToEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToEF
{
    class Program
    {
        static ImpactB1415Context context = new ImpactB1415Context();
        static void Main(string[] args)
        {
            Console.WriteLine("Department Info:");
            LinqToEf1();
            Console.WriteLine();
            List<Employee> employees = LinqToEf2(3);
            Console.WriteLine("Employees in Department No 3:");
            foreach (var employee in employees)
            {
                Console.WriteLine("Employee ID:{0}, First Name:{1}, Last Name:{2}, Salary:{3}",
                    employee.EmployeeId, employee.FirstName, employee.LastName, employee.Salary);
            }
            Console.WriteLine();
            decimal totalSalaryPaid = LinqToEf3();
            Console.WriteLine("Total Salary Expenditure is {0}",totalSalaryPaid);
            Console.WriteLine();
            int employeeCount = LinqToEf4();
            Console.WriteLine("Total Number of Employees are {0}",employeeCount);
            Console.WriteLine();
            Console.WriteLine("Linq To EF Group By:");
            LinqToEf5();
            Console.WriteLine();
            Console.WriteLine("Join using Linq to EF:");
            LinqToEf6();
            Console.ReadKey();
        }

        static void LinqToEf1()
        {
            var departments = context.Departments.ToList();
            foreach (var department in departments)
            {
                Console.WriteLine("Department ID:{0}, Name:{1}",
                    department.DepartmentId, department.Name);
            }
        }

        static List<Employee> LinqToEf2(int departmentId)
        {
            var empInDept = context.Employees.Where(dept => dept.DepartmentId == departmentId);
            return empInDept.ToList();
        }

        static decimal LinqToEf3()
        {
            decimal totalSalary = context.Employees.Sum(emp => emp.Salary);
            return totalSalary;
        }

        static int LinqToEf4()
        {
            int noOfEmployees = context.Employees.Count();
            return noOfEmployees;
        }

        static void LinqToEf5()
        {
            var empCount = context.Employees.GroupBy(emp=>emp.DepartmentId)
                .Select(e=>new {DepartmentId= e.Key, NoOfEmployees= e.Count()});
            foreach (var no in empCount)
            {
                Console.WriteLine("Department ID:{0}, No of Employees:{1}",
                    no.DepartmentId, no.NoOfEmployees);
            }
        }

        static void LinqToEf6()
        {
            var empDept = from dept in context.Departments
                          join emp in context.Employees
                          on dept.DepartmentId equals emp.DepartmentId
                          select new { FirstName = emp.FirstName, LastName = emp.LastName, DepartmentName = dept.Name };
            foreach (var edpt in empDept)
            {
                Console.WriteLine("First Name:{0}, Last Name:{1}, Department Name:{2}",
                    edpt.FirstName, edpt.LastName, edpt.DepartmentName);
            }
        }
    }
}
