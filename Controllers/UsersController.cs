using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recruitment_app.Data;
using recruitment_app.DTOs;
using recruitment_app.Models;

namespace recruitment_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateUser(UserCreateDto request)
        {
            var NewUser = new User
            {
                FirstName = request.FirstName,
                // LastName = request.LastName,
                // BirthdayDate = request.BirthdayDate,
            };

            foreach (var language in request.Languages)
            {
                var existingLanguage = await _context.Languages.FirstOrDefaultAsync(l => l.Name == language.Name) ?? throw new Exception("Language not found");
                existingLanguage.Users.Add(NewUser);
            }
            // var languages = request.Languages.Select(l => new Language { Name = l.Name, Users = new List<User> { NewUser } }).ToList();
            // NewUser.Languages = languages;

            _context.Users.Add(NewUser);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.Include(u => u.Languages).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.Languages)
                .FirstOrDefaultAsync(u => u.Uuid == id);

            return Ok(user);
        }
    }
}