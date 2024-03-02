using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserTree.Domain.Entities;
using UserTree.Infrastructure.Persistence.Base.Extensions;
using NvarcharLength = UserTree.Infrastructure.Persistence.Base.Extensions.NvarcharLength;

namespace UserTree.Infrastructure.Persistence.Configurations;

public class JournalEventsConfiguration : IEntityTypeConfiguration<JournalEvent>
{
    public void Configure(EntityTypeBuilder<JournalEvent> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Data)
            .HasMaxLength(NvarcharLength.Nvarchar4000);
        
        builder.Property(b => b.Type)
            .HasMaxLength(NvarcharLength.Nvarchar4000);
        builder.Property(b => b.RequestData)
            .HasMaxLength(NvarcharLength.Nvarchar4000);
        builder.Property(b => b.StackTrace)
            .HasMaxLength(NvarcharLength.Nvarchar4000);

    }
}