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
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
        [ActionName("GetDone")]
        public IActionResult GetDoneTodo()
        {

            return Ok(_Todoservices.GetTodos());

        }

        [HttpPost]
        public IActionResult AddTodo(Todos t)
        {
            _Todoservices.AddTodo(t);
            return Ok(t);
        }

        [HttpGet("{id}", Name ="GetTask")]
        public IActionResult GetTask(string id)
        {
            return Ok(_Todoservices.GetTask(id));
        }



        [HttpDelete("{id}")]

        public IActionResult DeleteTask(string id)
        {
            _Todoservices.DeleteTask(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateTask(Todos todo)
        {
            return Ok(_Todoservices.UpdateTask(todo));
        }


    }
}
