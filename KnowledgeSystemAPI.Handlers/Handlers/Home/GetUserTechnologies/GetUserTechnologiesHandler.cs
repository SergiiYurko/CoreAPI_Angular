﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KnowledgeSystemAPI.DataAccess.Interfaces;
using KnowledgeSystemAPI.Handlers.DTO;
using MediatR;

namespace KnowledgeSystemAPI.Handlers.Handlers.Home.GetUserTechnologies
{
    public class GetUserTechnologiesHandler: IRequestHandler<UserTechnologiesModelRequest, UserTechnologiesModelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserTechnologiesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserTechnologiesModelResponse> Handle(UserTechnologiesModelRequest request, CancellationToken cancellationToken)
        {
            var user = (await _unitOfWork.Users.GetWithIncludeAsync(u => u.UserId == request.Id)).FirstOrDefault();
            if (user != null)
            {
                var technologies = (await
                    _unitOfWork.UserTechnologies.GetWithIncludeAsync(p => p.UserId == user.UserId, i => i.Technology,
                        i => i.Technology.Group)).ToList();

                var technologyListDTO = _mapper.Map<List<TechnologyDTO>>(technologies);
                return _mapper.Map<UserTechnologiesModelResponse>(technologyListDTO);
            }

            return null;
        }
    }
}