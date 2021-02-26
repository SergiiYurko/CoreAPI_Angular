using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KnowledgeSystemAPI.DataAccess.Interfaces;
using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Account.LogIn
{
    public class LogInHandler: IRequestHandler<LogInModelRequest, LogInModelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LogInHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LogInModelResponse> Handle(LogInModelRequest request, CancellationToken cancellationToken)
        {
            var userInfo = (await _unitOfWork.Users.GetWithIncludeAsync(p => p.Email == request.Email && p.Password == request.Password, i => i.Role)).FirstOrDefault();

            return _mapper.Map<LogInModelResponse>(userInfo);
        }
    }
}