using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KnowledgeSystemAPI.DataAccess.Interfaces;
using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Profile.GetUserInfo
{
    public class GetUserInfoHandler: IRequestHandler<GetUserInfoModelRequest, GetUserInfoModelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetUserInfoModelResponse> Handle(GetUserInfoModelRequest request, CancellationToken cancellationToken)
        {
            var user = (await _unitOfWork.Users.GetAsync(p => p.UserId == request.Id)).FirstOrDefault();
            return user != null ? _mapper.Map<GetUserInfoModelResponse>(user) : null;
        }
    }
}