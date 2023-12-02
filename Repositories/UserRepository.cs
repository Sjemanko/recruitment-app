using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using recruitment_app.Data;
using recruitment_app.Models;

namespace recruitment_app.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddUser(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<User> DeleteUser(Guid uuid)
        {
            var user = await GetUserById(uuid);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserById(Guid uuid)
        {
            var user = await _context.Users.FindAsync(uuid) ?? throw new Exception("User not found");
            return user;
        }

        public async Task<User> GetUserByIdWithLanguages(Guid uuid)
        {
            var user = await _context.Users.Include(u => u.Languages).FirstOrDefaultAsync(u => u.Uuid == uuid) ?? throw new Exception("User not found");
            return user;
        }

        public async Task UpdateUser(User user, User updatedEntity)
        {
            _context.Entry(user).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
        }
    }
}