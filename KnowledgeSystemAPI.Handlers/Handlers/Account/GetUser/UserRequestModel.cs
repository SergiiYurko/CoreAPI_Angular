using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Home
{
    public class UserRequestModel: IRequest<UserResponseModel>
    {
        public int Id { get; set; }
    }
}