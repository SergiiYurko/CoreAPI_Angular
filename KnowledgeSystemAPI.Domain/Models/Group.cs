using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeSystemAPI.Domain.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public string TitleGroup { get; set; }
        public List<Technology> Technologies { get; set; } = new List<Technology>();
    }
}