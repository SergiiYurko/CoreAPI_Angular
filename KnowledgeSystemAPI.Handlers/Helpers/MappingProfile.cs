using AutoMapper;
using KnowledgeSystemAPI.Domain.Models;
using KnowledgeSystemAPI.Handlers.Handlers.Account.LogIn;
using KnowledgeSystemAPI.Handlers.Handlers.Home.GetUserRole;
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
                .ForMember(c => c.RoleType, m => m.MapFrom(c => c.Role.RoleType));

            CreateMap<User, GetUserInfoModelResponse>().ForMember(m => m.Id, d => d.MapFrom(v => v.UserId));

            CreateMap<UserTechnology, GetUserTechnologiesModelResponse>()
                .ForMember(m => m.GroupTitle, opt => opt.MapFrom(m => m.Technology.Group.TitleGroup))
                .ForMember(m => m.Title, opt => opt.MapFrom(m => m.Technology.TitleTechnology))
                .ForMember(m => m.Level, opt => opt.MapFrom(m => m.TechnologyLevel.ToString()));

            CreateMap<User, GetUserRoleModelResponse>()
                .ForMember(m => m.TypeRole, opt => opt.MapFrom(m => m.Role.RoleType));

            CreateMap<User, UpdateUserInfoModelResponse>();
        }
    }
}