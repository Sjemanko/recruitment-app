using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using recruitment_app.DTOs;
using recruitment_app.Models;

namespace recruitment_app.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> GetUsers();
        Task<ServiceResponse<GetUserDto>> GetUser(Guid id);
        Task<ServiceResponse<GetUserDto>> UpdateUser(Guid uuid, UpdateUserDto updatedUser);
        Task<ServiceResponse<DeleteUserDto>> DeleteUser(Guid id);
        Task<ServiceResponse<GetUserDto>> CreateUser(CreateUserDto request);
    }
}