using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KnowledgeSystemAPI.DataAccess.Interfaces;
using KnowledgeSystemAPI.Domain.Models;
using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Account.SignUp
{
    public class SignUpHandler: IRequestHandler<SignUpModelRequest, SignUpModelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public SignUpHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SignUpModelResponse> Handle(SignUpModelRequest request, CancellationToken cancellationToken)
        {
            var userInfo = (await _unitOfWork.Users.GetAsync(user => user.Email == request.Email)).FirstOrDefault();
            if (userInfo == null)
            {
                var role = (await _unitOfWork.Roles.GetWithIncludeAsync(p => p.RoleType.Type == "user", i => i.RoleType)).FirstOrDefault();
                _unitOfWork.Users.Create(new User{Email = request.Email, Password = request.Password, FirstName = request.FirstName, LastName = request.LastName, Role = role});
                _unitOfWork.SaveChangesAsync();
                return new SignUpModelResponse();
            }

            return null;
        }
    }
}