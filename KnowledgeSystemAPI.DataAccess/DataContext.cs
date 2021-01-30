using System.Collections.Generic;
using KnowledgeSystemAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeSystemAPI.DataAccess
{
    public sealed class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userList = new List<User>
            {
                new User {UserId = 1, FirstName = "Serhii", LastName = "Yurko"}
            };

            modelBuilder.Entity<User>().HasData(userList);
            base.OnModelCreating(modelBuilder);
        }
    }
}