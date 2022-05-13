﻿using Microsoft.AspNetCore.Http;
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

        [HttpPost, Route("Login")]

        public IActionResult Login([FromBody]Users user)
        {
            if (user == null)
                return BadRequest("Invalid Login");

            if(user.userame =="Hemanth" && user.Password =="Pass@123")
            {
                var secrectKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecrectKey@345"));
                var signingCredentials = new SigningCredentials(secrectKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(

                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                    
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });

            
            }
            return Unauthorized();
        }
    }
}
