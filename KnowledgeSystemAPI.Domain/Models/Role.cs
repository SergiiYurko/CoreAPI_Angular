using System.Collections.Generic;

namespace KnowledgeSystemAPI.Domain.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public int RoleTypeId { get; set; }
        public RoleType RoleType { get; set; }
        public ICollection<User> Users { get; set; }
    }
}