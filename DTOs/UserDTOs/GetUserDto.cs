using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using recruitment_app.Models;

namespace recruitment_app.DTOs
{
    public class GetUserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly BirthdayDate { get; set; }
        public string? Experience { get; set; }
        public string? SecondarySkills { get; set; }
        public List<GetLanguageDto>? Languages { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
    }
}