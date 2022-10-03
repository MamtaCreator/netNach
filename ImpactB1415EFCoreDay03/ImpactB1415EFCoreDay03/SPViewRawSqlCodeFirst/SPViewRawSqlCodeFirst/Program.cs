using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SPViewRawSqlCodeFirst.Models;
using System;
using System.Data;
using System.Linq;

namespace SPViewRawSqlCodeFirst
{
    class Program
    {
        static ImpactB1415Context context = new ImpactB1415Context();
        static void Main(string[] args)
        {
            //Please key in DepartmentId as per your Departments table to avoid the exception
            InsertProcedureCall("Saina", "Nehwal", 50000, 5);
            Console.WriteLine();
            ViewCall();
            Console.ReadKey();
        }

        static void InsertProcedureCall(string firstName,string lastName,decimal salary,int departmentId)
        {
            SqlParameter parameter1 = new SqlParameter("@FirstName", firstName);
            SqlParameter parameter2 = new SqlParameter("@LastName",lastName);
            SqlParameter parameter3 = new SqlParameter("@Salary", salary);
            SqlParameter parameter4 = new SqlParameter("@DepartmentId", departmentId);
            var result = context.Database.ExecuteSqlRaw("EXEC InsertEmployee @FirstName, @LastName, @Salary, @DepartmentId",
                parameter1, parameter2, parameter3, parameter4);
            if(result == 1)
                Console.WriteLine("Added employee record successfully");
            else
                Console.WriteLine("Failed to add employee record");
        }

        static void ViewCall()
        {
            var employees = context.EmployeesInfo.ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine("Employee ID:{0}, First Name:{1}, Last Name:{2}",
                    employee.EmployeeId,employee.FirstName,employee.LastName);
            }
        }
    }
}
