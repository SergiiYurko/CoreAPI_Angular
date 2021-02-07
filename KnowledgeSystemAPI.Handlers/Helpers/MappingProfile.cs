using System.Collections.Generic;
using AutoMapper;
using KnowledgeSystemAPI.Domain.Models;
using KnowledgeSystemAPI.Handlers.DTO;
using KnowledgeSystemAPI.Handlers.Handlers.Account.LogIn;
using KnowledgeSystemAPI.Handlers.Handlers.Home.GetUserTechnologies;

namespace KnowledgeSystemAPI.Handlers.Helpers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LogInModelResponse>()
                .ForMember(c => c.Name, m => m.MapFrom(c => c.FirstName + " " + c.LastName))
                .ForMember(c => c.Id, m => m.MapFrom(c => c.UserId));

            CreateMap<UserTechnology, TechnologyDTO>()
                .ForMember(m => m.GroupTitle, opt => opt.MapFrom(m => m.Technology.Group.TitleGroup))
                .ForMember(m => m.Title, opt => opt.MapFrom(m => m.Technology.TitleTechnology))
                .ForMember(m => m.Level, opt => opt.MapFrom(m => m.TechnologyLevel.ToString()));

            CreateMap<List<TechnologyDTO>, UserTechnologiesModelResponse>()
                .ForMember(m => m.TechnologyList, opt => opt.MapFrom(y => y));
        }
    }
}