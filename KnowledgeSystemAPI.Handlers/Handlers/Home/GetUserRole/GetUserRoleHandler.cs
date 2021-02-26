using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KnowledgeSystemAPI.DataAccess.Interfaces;
using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Home.GetUserRole
{
    public class GetUserRoleHandler: IRequestHandler<GetUserRoleModelRequest, GetUserRoleModelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserRoleHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetUserRoleModelResponse> Handle(GetUserRoleModelRequest request, CancellationToken cancellationToken)
        {
            var user = (await _unitOfWork.Users.GetWithIncludeAsync(p => p.UserId == request.Id, p => p.Role))
                .FirstOrDefault();

            return _mapper.Map<GetUserRoleModelResponse>(user);
        }
    }
}