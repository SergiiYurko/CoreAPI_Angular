using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeSystemAPI.Domain.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Technology> Technologies { get; set; } 
        public ICollection<UserTechnology> UserTechnologies { get; set; }
    }
}