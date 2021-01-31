using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystemAPI.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        void Create(TEntity item);
        Task<TEntity> FindByIdAsync(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}