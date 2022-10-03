using ContentNegotiationDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentNegotiationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepository _repository;

        public EmployeesController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public ActionResult<IEnumerable<Employee>> Get()
        {
            //return Ok(_repository.GetEmployees());
            return _repository.GetEmployees();
        }
    }
}
