using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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