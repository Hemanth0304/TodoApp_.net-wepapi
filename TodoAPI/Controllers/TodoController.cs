using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.core;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {

        private readonly ITodoservices _Todoservices;
        public TodoController(ITodoservices todoservices)
        {
            _Todoservices = todoservices;

        }
        [HttpGet]
        public IActionResult GetTodo()
        {
            return Ok(_Todoservices.GetTodos());

        }
        [HttpPost]
        public IActionResult AddTodo(Todos t)
        {
            _Todoservices.AddTodo(t);
            return Ok(t);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteTask(string id)
        {
            _Todoservices.DeleteTask(id);
            return NoContent();
        }


    }
}
