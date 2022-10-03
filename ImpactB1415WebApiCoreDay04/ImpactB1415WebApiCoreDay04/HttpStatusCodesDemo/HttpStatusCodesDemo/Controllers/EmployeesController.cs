using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HttpStatusCodesDemo.Models;
using System.Net.Http;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HttpStatusCodesDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployee _employee;

        public EmployeesController(IEmployee employee)
        {
            _employee = employee;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(_employee.GetAllEmployees());
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            
            var employee = _employee.GetEmployeeById(id);
            if (employee == null)
                return NotFound();
            //return NotFound(JsonConvert.SerializeObject(new { Key = 404, Value = "Employee with id " + id + " does not exists" })); 
            return Ok(_employee.GetEmployeeById(id));
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            _employee.AddEmployee(employee);
            return Created($"~api/Employees/{employee.EmployeeId}",employee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
        {
            _employee.UpdateEmployee(id, employee);
            return employee;
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            _employee.DeleteEmployee(id);
            //return id;
            return NoContent();
        }
        [HttpGet("getsal")]
        public ActionResult<int> GetSalary([FromBody] Employee employee)
        {
            return BadRequest();
        }
    }
}
