using KnowledgeSystemAPI.Domain.Models;

namespace KnowledgeSystemAPI.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<UserTechnology> UserTechnologies { get; }
        void SaveChanges();
    }
}