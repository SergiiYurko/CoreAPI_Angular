using System.Threading;
using System.Threading.Tasks;
using KnowledgeSystemAPI.DataAccess.Interfaces;
using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Home
{
    public class GetUserHandler: IRequestHandler<UserRequestModel, UserResponseModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResponseModel> Handle(UserRequestModel request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(request.Id);
            return user != null ? new UserResponseModel {FirstName = user.FirstName, LastName = user.LastName} : null;
        }
    }
}