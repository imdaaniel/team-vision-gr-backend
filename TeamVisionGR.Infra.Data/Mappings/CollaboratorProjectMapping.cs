using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Infra.Data.Mappings
{
    public class CollaboratorProjectMapping : IEntityTypeConfiguration<CollaboratorProject>
    {
        public void Configure(EntityTypeBuilder<CollaboratorProject> builder)
        {
            builder.HasKey(e => new
            {
                e.CollaboratorId,
                e.ProjectId
            });

            builder.HasOne(e => e.Collaborator)
                .WithMany(e => e.CollaboratorProjects)
                .HasForeignKey(e => e.CollaboratorId);

            builder.HasOne(e => e.Project)
                .WithMany(e => e.CollaboratorProjects)
                .HasForeignKey(e => e.ProjectId);

            builder.Property(e => e.EntryDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.LeavingDate)
                .IsRequired(false);
        }
    }
}