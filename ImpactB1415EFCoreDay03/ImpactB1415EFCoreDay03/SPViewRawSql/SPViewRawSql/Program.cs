using Microsoft.EntityFrameworkCore;
using SPViewRawSql.Models;
using System;

namespace SPViewRawSql
{
    class Program
    {
        static ImpactB1415Context context = new ImpactB1415Context();
        static void Main(string[] args)
        {
            RetrieveSPCall(1004);
            Console.WriteLine();
            ExecuteRawSql();
            Console.ReadKey();
        }

        static void RetrieveSPCall(int employeeId)
        {
            var employee = context.Employees.FromSqlRaw($"GetEmployee {employeeId}");
            foreach (var emp in employee)
            {
                Console.WriteLine("Employee ID:{0}, First Name:{1}, Last Name:{2}, Salary:{3}",
                    emp.EmployeeId, emp.FirstName, emp.LastName, emp.Salary);
            }
        }

        static void ExecuteRawSql()
        {
            var employees = context.Employees.FromSqlRaw("SELECT * FROM Employees");
            foreach (var employee in employees)
            {
                Console.WriteLine("Employee ID:{0}, First Name:{1}, Last Name:{2}, Salary:{3}",
                    employee.EmployeeId, employee.FirstName, employee.LastName, employee.Salary);
            }
        }
    }
}
