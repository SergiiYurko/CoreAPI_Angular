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
                if (request.FirstName != null)
                    user.FirstName = request.FirstName;

                if (request.LastName != null)
                    user.LastName = request.LastName;

                if (request.Password != null)
                    user.Password = request.Password;

                if (request.Email != null)
                    user.Email = request.Email;

                //_unitOfWork.SaveChangesAsync();
                return _mapper.Map<UpdateUserInfoModelResponse>(user);
            }

            return null;
        }
    }
}