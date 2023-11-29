using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recruitment_app.Data;
using recruitment_app.DTOs;
using recruitment_app.Models;
using recruitment_app.Services;

namespace recruitment_app.Controllers
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
        public async Task<ActionResult<ServiceResponse<User>>> PostUser(CreateUserDto request)
        {
            var serviceResponse = await _userService.CreateUser(request);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<User>> GetUserById(Guid id)
        // {
        //     var user = await _context.Users
        //         .Include(u => u.Languages)
        //         .FirstOrDefaultAsync(u => u.Uuid == id);

        //     return Ok(user);
        // }
    }
}