using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Infra.Data.Mappings
{
    public class CollaboratorMapping : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}