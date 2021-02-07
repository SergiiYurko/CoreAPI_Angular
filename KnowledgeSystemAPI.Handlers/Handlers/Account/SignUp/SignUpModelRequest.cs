using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Account.SignUp
{
    public class SignUpModelRequest: IRequest<SignUpModelResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}