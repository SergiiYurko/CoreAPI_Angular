using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KnowledgeSystemAPI.DataAccess.Interfaces;
using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Profile.UpdateUserInfo
{
    public class UpdateUserInfoHandler: IRequestHandler<UpdateUserInfoModelRequest, UpdateUserInfoModelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateUserInfoModelResponse> Handle(UpdateUserInfoModelRequest request, CancellationToken cancellationToken)
        {
            var user = (await _unitOfWork.Users.GetAsync(p => p.UserId == request.Id)).FirstOrDefault();
            if (user != null)
            {
                if (!string.IsNullOrEmpty(request.Email))
                    user.Email = request.Email;
                if (!string.IsNullOrEmpty(request.FirstName))
                    user.FirstName = request.FirstName;
                if (!string.IsNullOrEmpty(request.LastName))
                    user.LastName = request.LastName;
                if (!string.IsNullOrEmpty(request.Password))
                    user.Password = request.Password;

                _unitOfWork.Users.Update(user);
                _unitOfWork.SaveChangesAsync();

                return _mapper.Map<UpdateUserInfoModelResponse>(user);
            }

            return null;
        }
    }
}