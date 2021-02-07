using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeSystemAPI.Domain.Models
{
    public class Technology
    {
        [Key]
        public int TechnologyId { get; set; }
        public string TitleTechnology { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<UserTechnology> UserTechnologies { get; set; }
    }
}