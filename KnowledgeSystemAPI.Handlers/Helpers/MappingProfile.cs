using AutoMapper;
using KnowledgeSystemAPI.Domain.Models;
using KnowledgeSystemAPI.Handlers.Handlers.Account.LogIn;
using KnowledgeSystemAPI.Handlers.Handlers.Home.GetUserTechnologies;
using KnowledgeSystemAPI.Handlers.Handlers.Profile.GetUserInfo;
using KnowledgeSystemAPI.Handlers.Handlers.Profile.UpdateUserInfo;

namespace KnowledgeSystemAPI.Handlers.Helpers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LogInModelResponse>()
                .ForMember(c => c.Name, m => m.MapFrom(c => c.FirstName + " " + c.LastName))
                .ForMember(c => c.Id, m => m.MapFrom(c => c.UserId))
                .ForMember(c => c.RoleType, m => m.MapFrom(c => c.Role.RoleType.Type));

            CreateMap<User, GetUserInfoModelResponse>();

            CreateMap<UserTechnology, GetUserTechnologiesModelResponse>()
                .ForMember(m => m.GroupTitle, opt => opt.MapFrom(m => m.Technology.Group.TitleGroup))
                .ForMember(m => m.Title, opt => opt.MapFrom(m => m.Technology.TitleTechnology))
                .ForMember(m => m.Level, opt => opt.MapFrom(m => m.TechnologyLevel.ToString()));

            CreateMap<User, UpdateUserInfoModelResponse>()
                .ForMember(m => m.Id, opt => opt.MapFrom(m => m.UserId))
                .ForMember(m => m.FullName, opt => opt.MapFrom(m => m.FirstName + " " + m.LastName));
        }
    }
}