using System.Collections.Generic;

namespace KnowledgeSystemAPI.Domain.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleType { get; set; }
        public ICollection<User> Users { get; set; }
    }
}