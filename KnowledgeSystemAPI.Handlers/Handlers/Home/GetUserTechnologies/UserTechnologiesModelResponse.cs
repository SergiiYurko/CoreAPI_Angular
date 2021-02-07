using System.Collections.Generic;
using KnowledgeSystemAPI.Handlers.DTO;

namespace KnowledgeSystemAPI.Handlers.Handlers.Home.GetUserTechnologies
{
    public class UserTechnologiesModelResponse
    {
        public List<TechnologyDTO> TechnologyList{ get; set; }
    }
}