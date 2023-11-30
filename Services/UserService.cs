using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
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
                var newUser = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    BirthdayDate = request.BirthdayDate,
                    Email = request.Email,
                    Image = request.Image,
                    Experience = request.Experience,
                    SecondarySkills = request.SecondarySkills
                };

                foreach (var language in request.Languages)
                {
                    var existingLanguage = await _context.Languages.FirstOrDefaultAsync(l => l.Name == language.Name) ?? throw new ArgumentNullException(null, "Language not found");
                    newUser.Languages.Add(existingLanguage);
                }

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetUserDto>(await _context.Users.FirstAsync(u => u.Uuid == newUser.Uuid));
            }
            catch (ArgumentNullException ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<DeleteUserDto>> DeleteUser(Guid id)
        {
            var serviceResponse = new ServiceResponse<DeleteUserDto>();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Uuid == id) ?? throw new ArgumentNullException(null, "User not found.");
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<DeleteUserDto>(user);
                serviceResponse.Message = $"User has been deleted.";
            }
            catch (ArgumentNullException ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUser(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var user = await _context.Users.Include(u => u.Languages).FirstOrDefaultAsync(u => u.Uuid == id) ?? throw new ArgumentNullException(null, "User not found.");
                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }
            catch (ArgumentNullException ex)
            {
                serviceResponse.Data = null;
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>
            {
                Data = await _context.Users.Include(u => u.Languages).Select(u => _mapper.Map<GetUserDto>(u)).ToListAsync()
            };

            return serviceResponse;
        }

        public Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}