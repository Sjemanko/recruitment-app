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
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> PostUser(CreateUserDto request)
        {
            var serviceResponse = await _userService.CreateUser(request);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<User>> GetUserById(Guid id)
        // {
        //     var user = await _userService.Users
        //         .Include(u => u.Languages)
        //         .FirstOrDefaultAsync(u => u.Uuid == id);

        //     return Ok(user);
        // }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<DeleteUserDto>>> DeleteUser(Guid id)
        {
            var serviceResponse = await _userService.DeleteUser(id);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetUserById(Guid id)
        {
            var serviceResponse = await _userService.GetUser(id);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> UpdateUser(Guid id, UpdateUserDto request)
        {
            var serviceResponse = await _userService.UpdateUser(id, request);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }
    }
}