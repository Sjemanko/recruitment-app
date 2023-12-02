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
using recruitment_app.Repositories;

namespace recruitment_app.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository<User> _repository;

        public UserService(AppDbContext context, IMapper mapper, IUserRepository<User> repository)
        {
            _context = context;
            _mapper = mapper;
            _repository = repository;
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

                await _repository.AddUser(newUser);

                // serviceResponse.Data = _mapper.Map<GetUserDto>(await _context.Users.FirstAsync(u => u.Uuid == newUser.Uuid));

                serviceResponse.Data = _mapper.Map<GetUserDto>(_repository.GetUserById(newUser.Uuid));
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
                // var user = await _context.Users.FirstOrDefaultAsync(u => u.Uuid == id) ?? throw new ArgumentNullException(null, "User not found.");
                // _context.Users.Remove(user);
                // await _context.SaveChangesAsync();

                var deletedUser = await DeleteUser(id);
                serviceResponse.Data = _mapper.Map<DeleteUserDto>(deletedUser);
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
                // var user = await _context.Users.Include(u => u.Languages).FirstOrDefaultAsync(u => u.Uuid == id) ?? throw new ArgumentNullException(null, "User not found.");

                var user = await _repository.GetUserByIdWithLanguages(id);
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
                // To change (move to repository)
                Data = await _context.Users.Include(u => u.Languages).Select(u => _mapper.Map<GetUserDto>(u)).ToListAsync()
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(Guid uuid, UpdateUserDto updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var existingUser = await _repository.GetUserById(uuid);
                await _repository.UpdateUser(existingUser, _mapper.Map<User>(updatedUser));
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}