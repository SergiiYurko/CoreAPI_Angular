using KnowledgeSystemAPI.Domain.Models;

namespace KnowledgeSystemAPI.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<UserTechnology> UserTechnologies { get; }
        IRepository<Role> Roles{ get; }
        void SaveChangesAsync();
    }
}