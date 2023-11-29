using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using recruitment_app.Models;

namespace recruitment_app.DTOs
{
    public record struct GetUserDto(
        string FirstName,
        string LastName,
        DateOnly BirthdayDate,
        List<Language> Languages,
        string Email,
        string Image
    );
}