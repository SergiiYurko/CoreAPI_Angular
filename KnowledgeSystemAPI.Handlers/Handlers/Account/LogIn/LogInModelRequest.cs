using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Account.LogIn
{
    public class LogInModelRequest: IRequest<LogInModelResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}