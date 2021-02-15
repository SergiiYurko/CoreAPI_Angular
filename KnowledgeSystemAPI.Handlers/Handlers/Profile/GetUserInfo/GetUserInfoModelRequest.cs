using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Profile.GetUserInfo
{
    public class GetUserInfoModelRequest: IRequest<GetUserInfoModelResponse>
    {
        public int Id { get; set; }
    }
}