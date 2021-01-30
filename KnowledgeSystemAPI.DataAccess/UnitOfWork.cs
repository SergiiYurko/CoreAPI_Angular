using System;
using KnowledgeSystemAPI.DataAccess.Interfaces;
using KnowledgeSystemAPI.Domain.Models;

namespace KnowledgeSystemAPI.DataAccess
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly DataContext _dbContext;
        private IRepository<User> _userRepository;

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<User> Users => _userRepository ??= new Repository<User>(_dbContext);

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        private bool _disposed;
        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
           Dispose(true);
           GC.SuppressFinalize(this);
        }
    }
}