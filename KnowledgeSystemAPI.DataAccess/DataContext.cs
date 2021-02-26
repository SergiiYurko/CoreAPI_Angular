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
        public DbSet<Group> Groups { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<UserTechnology> UserTechnologies { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var roleList = new List<Role>
            {
                new Role {RoleId = 1, RoleType = "user"},
                new Role {RoleId = 2, RoleType = "admin"}
            };

            var groupList = new List<Group>
            {
                new Group {GroupId = 1, TitleGroup = ".NET"}
            };

            var technologyList = new List<Technology>
            {
                new Technology {TechnologyId = 1, GroupId = 1, TitleTechnology = ".NET 5"},
                new Technology {TechnologyId = 2, GroupId = 1, TitleTechnology = ".NET Framework 4.8"},
                new Technology {TechnologyId = 3, GroupId = 1, TitleTechnology = "EF 6"},
                new Technology {TechnologyId = 4, GroupId = 1, TitleTechnology = "ASP.NET MVC 5"}
            };

            var userList = new List<User>
            {
                new User
                {
                    UserId = 1, FirstName = "Serhii", LastName = "Yurko", Email = "admin@com", Password = "admin", RoleId = 2
                }

            };

            var userTechnologyList = new List<UserTechnology>
            {
                new UserTechnology
                    {UserTechnologyId = 1, TechnologyId = 1, UserId = 1, TechnologyLevel = TechnologyLevel.Novice},
                new UserTechnology
                    {UserTechnologyId = 2, TechnologyId = 2, UserId = 1, TechnologyLevel = TechnologyLevel.Advanced},
                new UserTechnology
                    {UserTechnologyId = 3, TechnologyId = 3, UserId = 1, TechnologyLevel = TechnologyLevel.Advanced}
            };

            modelBuilder.Entity<Technology>().HasOne(exp => exp.Group).WithMany(exp => exp.Technologies)
                .HasForeignKey(exp => exp.GroupId);
            
            modelBuilder.Entity<Technology>().HasMany(c => c.Users).WithMany(s => s.Technologies)
                .UsingEntity<UserTechnology>(
                    j => j.HasOne(pt => pt.User).WithMany(t => t.UserTechnologies).HasForeignKey(k => k.UserId),
                    j => j.HasOne(t => t.Technology).WithMany(t => t.UserTechnologies)
                        .HasForeignKey(k => k.TechnologyId),
                    j =>
                    {
                        j.HasKey(t => new {t.UserId, t.TechnologyId});
                    }
                );

            modelBuilder.Entity<UserTechnology>().Property(p => p.TechnologyLevel).HasConversion<string>();

            modelBuilder.Entity<User>().HasData(userList);
            modelBuilder.Entity<Group>().HasData(groupList);
            modelBuilder.Entity<Technology>().HasData(technologyList);
            modelBuilder.Entity<UserTechnology>().HasData(userTechnologyList);
            modelBuilder.Entity<Role>().HasData(roleList);

            base.OnModelCreating(modelBuilder);
        }
    }
}