using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recruitment_app.DTOs
{
    public record struct CreateUserDto(
        string FirstName,
        string LastName,
        DateOnly BirthdayDate,
        List<LanguageCreateDto> Languages,
        string Email,
        string Image
    );
}