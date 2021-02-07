using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace KnowledgeSystemAPI.Domain.Models
{
    public class UserTechnology
    {
        public int UserTechnologyId { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }
        public TechnologyLevel TechnologyLevel { get; set; }
    }

    public enum TechnologyLevel
    {
        Novice,
        Intermediate, 
        Advanced
    }
}