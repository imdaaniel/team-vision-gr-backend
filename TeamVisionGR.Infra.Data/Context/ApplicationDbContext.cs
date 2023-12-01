using Microsoft.EntityFrameworkCore;

using TeamVisionGR.Domain.Entities;
using TeamVisionGR.Infra.Data.Mappings;

namespace TeamVisionGR.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<UserActivation> UserActivation { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Collaborator> Collaborator { get; set; }
        public DbSet<CollaboratorProject> CollaboratorProject { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new ProjectMapping());
            modelBuilder.ApplyConfiguration(new CollaboratorMapping());

            // base.OnModelCreating(modelBuilder);
        }
    }
}