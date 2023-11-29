using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recruitment_app.DTOs
{
    public record struct DeleteUserDto(
        Guid Id
    );
}