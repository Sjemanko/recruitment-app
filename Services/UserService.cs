using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using recruitment_app.Data;
using recruitment_app.DTOs;
using recruitment_app.Models;

namespace recruitment_app.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetUserDto>> CreateUser(CreateUserDto request)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var NewUser = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    BirthdayDate = request.BirthdayDate,
                    Email = request.Email,
                    Image = request.Image,
                };

                foreach (var language in request.Languages)
                {
                    var existingLanguage = await _context.Languages.FirstOrDefaultAsync(l => l.Name == language.Name) ?? throw new Exception("Language not found");
                    NewUser.Languages.Add(existingLanguage);
                }

                _context.Users.Add(NewUser);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetUserDto>(await _context.Users.FirstAsync(u => u.Uuid == NewUser.Uuid));
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<GetUserDto>> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetUserDto>> GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetUserDto>>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}