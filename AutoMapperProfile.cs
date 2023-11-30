using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using recruitment_app.DTOs;
using recruitment_app.Models;

namespace recruitment_app
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<User, DeleteUserDto>();
            CreateMap<Language, GetLanguageDto>();
        }
    }
}