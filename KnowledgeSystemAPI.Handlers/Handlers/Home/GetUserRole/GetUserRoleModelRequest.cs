using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Home.GetUserRole
{
    public class GetUserRoleModelRequest: IRequest<GetUserRoleModelResponse>
    {
        public int Id { get; set; }
    }
}