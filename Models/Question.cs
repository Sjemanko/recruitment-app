using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace recruitment_app.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Uuid { get; set; }
        public string? Contents { get; set; }
        public List<Language> Languages { get; set; } = new();
        public DateOnly CreatedAt { get; init; }
        public DateOnly UpdatedAt { get; set; }
    }
}