using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Npgsql.Internal.TypeHandlers;

namespace recruitment_app.Models
{
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; } = new();
        public List<Question> Questions { get; set; } = new();
    }
}