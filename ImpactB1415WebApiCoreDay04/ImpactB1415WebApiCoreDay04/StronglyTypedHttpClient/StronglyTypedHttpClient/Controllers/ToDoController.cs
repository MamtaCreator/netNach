using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StronglyTypedHttpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StronglyTypedHttpClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private ITodoService _todoService;

        public ToDoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [HttpGet]
        public async Task<List<ToDo>> GetTodos()
        {
            var todos = await _todoService.GetAllAsync();
            return todos;
        }
        [HttpGet("{id}")]
        public async Task<ToDo> GetTodoAsync(int id)
        {
            var toDo = await _todoService.GetTodoAsync(id);
            return toDo;
        }
        [HttpPost]
        public async Task<ToDo> PostTodoAsync([FromBody]ToDo task)
        {
            var toDo = await _todoService.CreateTodoAsync(task);
            return toDo;
        }
    }
}
