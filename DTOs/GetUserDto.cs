using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recruitment_app.DTOs
{
    public record struct GetUserDto(
        string FirstName,
        string LastName,
        DateOnly BirthdayDate,
        List<LanguageCreateDto> Languages,
        string Email,
        string Image
    );
}