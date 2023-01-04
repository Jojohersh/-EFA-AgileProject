using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Models.User;
using Agile.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Agile.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;
        }
    
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var registerResult = await _userService.RegisterUserAsync(model);
                if (registerResult)
                {
                    return Ok("User was registered.");
                }
                return BadRequest("User could not be registered.");
            }

        [HttpGet("{userId:int}")]    
        public async Task<IActionResult> GetById([FromRoute] int userId)
            {
               //int userDbId = int.Parse(User.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.NameIdentifier).Value);
                var userDetail = await _userService.GetUserByIdAsync(userId);
                if(userDetail is null)
                {
                    return NotFound();
                }
                return Ok(userDetail);
            }    



    }
}