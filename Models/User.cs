using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Npgsql.Internal.TypeHandlers;

namespace recruitment_app.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Uuid { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateOnly BirthdayDate { get; set; }
        public string? SecondarySkills { get; set; }
        public string? Experience { get; set; }
        public Role Role { get; set; } = Role.USER;
        public string? Image { get; set; }
        public List<Language> Languages { get; set; } = new();
        public DateOnly CreatedAt { get; init; }
        public DateOnly UpdatedAt { get; set; }
    }
}