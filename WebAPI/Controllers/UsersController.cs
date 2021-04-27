using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("userid")]
        public IActionResult GetCarsByUserId(int id)
        {
            var result = _userService.GetCarsByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}

