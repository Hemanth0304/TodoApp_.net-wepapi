using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Todo.core;

namespace TodoAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _UserServices;
        public AuthController(IUserService userservices)
        {
            _UserServices = userservices;
        }

        [HttpPost, Route("Todo")]

        public IActionResult Login([FromBody]Users credentials)
        {

            
            if (credentials == null) { return BadRequest("Invalid Login"); } else
            {

                var us = _UserServices.GetUsers().Where(a => a.userame == credentials.userame).FirstOrDefault();
                var ps = _UserServices.GetUsers().Where(a => a.Password == credentials.Password).FirstOrDefault();

                if (us!= null && ps!=null)
                {
                    var secrectKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecrectKey@345"));
                    var signingCredentials = new SigningCredentials(secrectKey, SecurityAlgorithms.HmacSha256);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, credentials.userame ),
                        new Claim(ClaimTypes.Role, "Admin")
                    };

                    var tokenOptions = new JwtSecurityToken(

                        issuer: "https://localhost:5001",
                        audience: "https://localhost:4200",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signingCredentials

                        );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new { Token = tokenString,
                   StatusCode =200,
                    Message = "Logged in Successfully"
                    });



                }

            }
             


           
            return Unauthorized();
        }
    }
}
