using BNP.DataAccess.Configuration;
using BNP.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserFile = BNP.Domain.Entities.UserFile;

namespace BNP.DataAccess
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }

        public virtual DbSet<UserFile> UserFile { get; set; }
        public virtual DbSet<FileHistory> FileHistory { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.Entity<UserFile>()
                                       .HasMany(c => c.FileHistory)
                                       .WithOne(e => e.UserFile);
        }

    }
}
