using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KnowledgeSystemAPI.DataAccess.Interfaces;
using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Account.LogIn
{
    public class LogInHandler: IRequestHandler<LogInModelRequest, LogInModelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public LogInHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LogInModelResponse> Handle(LogInModelRequest request, CancellationToken cancellationToken)
        {
            var userInfo = (await _unitOfWork.Users.GetAsync(user => request.Email == user.Email && request.Password == user.Password)).FirstOrDefault();
            if (userInfo != null)
                return new LogInModelResponse {FirstName = userInfo.FirstName, LastName = userInfo.LastName};
            return null;
        }
    }
}
