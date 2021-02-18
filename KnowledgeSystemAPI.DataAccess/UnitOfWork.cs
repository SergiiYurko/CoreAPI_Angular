using System;
using KnowledgeSystemAPI.DataAccess.Interfaces;
using KnowledgeSystemAPI.Domain.Models;

namespace KnowledgeSystemAPI.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _dbContext;
        private IRepository<User> _userRepository;
        private IRepository<UserTechnology> _userTechnologiesRepository;
        private IRepository<Role> _roleRepository;

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<User> Users => _userRepository ??= new Repository<User>(_dbContext);
        public IRepository<UserTechnology> UserTechnologies => _userTechnologiesRepository ??= new Repository<UserTechnology>(_dbContext);
        public IRepository<Role> Roles => _roleRepository ??= new Repository<Role>(_dbContext);

        public void SaveChangesAsync()
        {
            _dbContext.SaveChangesAsync();
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