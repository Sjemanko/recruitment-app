using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using recruitment_app.DTOs;
using recruitment_app.Models;

namespace recruitment_app.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(Guid uuid);
        Task AddUser(User entity);
        Task UpdateUser(User user, UpdateUserDto updatedEntity);
        Task<User> DeleteUser(Guid uuid);
        Task<User> GetUserByIdWithLanguages(Guid uuid);
    }
}