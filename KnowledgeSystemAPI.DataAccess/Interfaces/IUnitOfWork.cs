using KnowledgeSystemAPI.Domain.Models;

namespace KnowledgeSystemAPI.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        void SaveChanges();
    }
}