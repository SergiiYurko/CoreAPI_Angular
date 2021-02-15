using System.Collections.Generic;
using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Home.GetUserTechnologies
{
    public class GetUserTechnologiesModelRequest: IRequest<List<GetUserTechnologiesModelResponse>>
    {
        public int UserId { get; set; }
    }
}