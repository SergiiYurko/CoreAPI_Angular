using System.Collections.Generic;
using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Home.GetUserTechnologies
{
    public class UserTechnologiesModelRequest: IRequest<List<UserTechnologiesModelResponse>>
    {
        public int UserId { get; set; }
    }
}