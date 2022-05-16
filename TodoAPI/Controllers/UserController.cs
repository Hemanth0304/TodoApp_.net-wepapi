using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.core;


namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService  _UserServices;
        public UserController(IUserService userservices)
        {
            _UserServices = userservices;
        }





        // GET: api/<UserController>
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(_UserServices.GetUsers());

        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult AddUser(Users user)
        {
            _UserServices.AddUsers(user);
            return Ok(user);
        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
