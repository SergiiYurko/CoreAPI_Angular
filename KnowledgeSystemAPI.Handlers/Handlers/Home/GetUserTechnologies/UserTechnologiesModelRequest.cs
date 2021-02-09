using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Home.GetUserTechnologies
{
    public class UserTechnologiesModelRequest: IRequest<UserTechnologiesModelResponse>
    {
        public int UserId { get; set; }
    }
}