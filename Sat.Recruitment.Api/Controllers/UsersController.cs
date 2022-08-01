using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Helpers;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {        
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("create-user")]
        [ProducesResponseType(typeof(Result), 200)]
        public async Task<Result> CreateUser([FromBody] User request)
        {            
            return await _userService.Create(request);            
        }
    }
}
