using EFCoreDbFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreDbFirst
{
    class Program
    {
        static ImpactB1415Context context = new ImpactB1415Context();
        static void Main(string[] args)
        {
            Department department = new Department();
            Console.Write("Enter Department Name:");
            department.Name = Console.ReadLine();
            List<Department> departments = null;
            bool isDeptAdded = AddDepartment(department);
            if (isDeptAdded)
            {
                Console.WriteLine("Department information added successfully");
                departments = GetDepartments();
                foreach (Department dept in departments)
                {
                    Console.WriteLine("Department ID:{0}, Name:{1}",
                        dept.DepartmentId, dept.Name);
                }
            }
            else
                Console.WriteLine("Failed to add department information");
            int departmentId;
            Console.Write("Enter the Id to locate the Department:");
            departmentId = Convert.ToInt32(Console.ReadLine());
            department = new Department();
            Console.Write("Enter the Department Name:");
            department.Name = Console.ReadLine();
            bool isDeptEdited = EditDepartment(departmentId, department);
            if (isDeptEdited)
            {
                Console.WriteLine("Department information updated successfully");
                departments = GetDepartments();
                foreach (Department dept in departments)
                {
                    Console.WriteLine("Department ID:{0}, Name:{1}",
                        dept.DepartmentId, dept.Name);
                }
            }
            else
                Console.WriteLine("Failed to update department information");
            Console.Write("Enter the Id to delete the Department:");
            departmentId = Convert.ToInt32(Console.ReadLine());
            bool isDeptDeleted = DeleteDepartment(departmentId);
            if (isDeptDeleted)
            {
                Console.WriteLine("Department information deleted successfully");
                departments = GetDepartments();
                foreach (Department dept in departments)
                {
                    Console.WriteLine("Department ID:{0}, Name:{1}",
                        dept.DepartmentId, dept.Name);
                }
            }
            else
                Console.WriteLine("Failed to delete department information");
            Console.WriteLine("Enter the DepartmentId to get the Department information");
            departmentId = Convert.ToInt32(Console.ReadLine());
            Department existingDept = GetDepartment(departmentId);
            if (existingDept != null)
            {
                Console.WriteLine("Department ID:{0}, Name:{1}",
                    existingDept.DepartmentId, existingDept.Name);
            }
            else
                Console.WriteLine("Department with Id {0} does not exist", departmentId);
            departments = GetDepartments();
            Console.WriteLine("Displaying Department Information:");
            foreach (Department dept in departments)
            {
                Console.WriteLine("Department ID:{0}, Name:{1}",
                    dept.DepartmentId, dept.Name);
            }
            Console.WriteLine();
            Employee employee = new Employee();
            Console.Write("Enter first name:");
            employee.FirstName = Console.ReadLine();
            Console.Write("Enter last name:");
            employee.LastName = Console.ReadLine();
            Console.Write("Enter the Salary:");
            employee.Salary = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter the Department:");
            employee.DepartmentId = Convert.ToInt32(Console.ReadLine());
            List<Employee> employees = null;
            bool isEmpAdded = AddEmployee(employee);
            if (isEmpAdded)
            {
                Console.WriteLine("Added employee information successfully");
                employees = GetEmployees();
                Console.WriteLine("Displaying Employee Information:");
                foreach (Employee emp in employees)
                {
                    Console.WriteLine(emp);
                }
            }

            int employeeId;
            Console.Write("Enter the Employee Id to view the details:");
            employeeId = Convert.ToInt32(Console.ReadLine());
            Employee existingEmp = GetEmployee(employeeId);
            if(existingEmp!=null)
            {
                Console.WriteLine(existingEmp);
            }
            else
                Console.WriteLine("Employee with Id {0} does not exist",employeeId);
            Console.ReadKey();
        }

        static bool AddDepartment(Department department)
        {
            bool isDeptAdded = false;
            context.Departments.Add(department);
            Console.WriteLine("Current State is {0}",context.Entry(department).State);
            int result = context.SaveChanges();
            if (result > 0)
                isDeptAdded = true;
            return isDeptAdded;
        }

        static List<Department> GetDepartments()
        {
            return context.Departments.ToList();
        }

        static bool EditDepartment(int departmentId,Department department)
        {
            bool isDeptEdited = false;
            Department existingDept = context.Departments.FirstOrDefault(dept => dept.DepartmentId == departmentId);
            if(existingDept!=null)
            {
                existingDept.Name = department.Name;
                Console.WriteLine("Current State is {0}", context.Entry(existingDept).State);
                int result = context.SaveChanges();          
                if (result > 0)
                    isDeptEdited = true;
            }
            return isDeptEdited;
        }

        static bool DeleteDepartment(int departmentId)
        {
            bool isDeptDeleted = false;
            Department existingDept = context.Departments.FirstOrDefault(dept => dept.DepartmentId == departmentId);
            if(existingDept!=null)
            {
                context.Departments.Remove(existingDept);
                Console.WriteLine("Current State is {0}", context.Entry(existingDept).State);
                int result = context.SaveChanges();
                if (result > 0)
                    isDeptDeleted = true;
            }
            return isDeptDeleted;
        }

        static Department GetDepartment(int departmentId)
        {
            return context.Departments.FirstOrDefault(dept => dept.DepartmentId == departmentId);
        }

        static bool AddEmployee(Employee employee)
        {
            bool isEmpAdded = false;
            context.Employees.Add(employee);
            int result = context.SaveChanges();
            if (result > 0)
                isEmpAdded = true;
            return isEmpAdded;
        }

        static List<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }

        static Employee GetEmployee(int employeeId)
        {
            return context.Employees.FirstOrDefault(emp => emp.EmployeeId == employeeId);
        }
    }
}
