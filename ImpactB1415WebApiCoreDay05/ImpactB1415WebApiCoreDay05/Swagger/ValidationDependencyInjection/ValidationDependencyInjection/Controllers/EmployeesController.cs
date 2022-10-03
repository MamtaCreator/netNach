using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidationDependencyInjection.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ValidationDependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepository employeeRepository = null;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return employeeRepository.GetEmployees();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return employeeRepository.GetEmployee(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            employeeRepository.AddEmployee(employee);
            return employee;
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
        {
            employeeRepository.UpdateEmployee(id,employee);
            return employee;
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            employeeRepository.DeleteEmployee(id);
            return id;
        }
    }
}
