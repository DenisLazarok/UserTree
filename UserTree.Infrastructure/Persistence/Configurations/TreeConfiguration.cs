using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserTree.Domain.Entities;
using UserTree.Infrastructure.Persistence.Base.Extensions;
using NvarcharLength = UserTree.Infrastructure.Persistence.Base.Extensions.NvarcharLength;

namespace UserTree.Infrastructure.Persistence.Configurations;

public class TreeConfiguration : IEntityTypeConfiguration<Tree>
{
    public void Configure(EntityTypeBuilder<Tree> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasIndex(b => b.Name)
            .IsUnique();

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(NvarcharLength.Nvarchar2048);


        builder.HasMany(x => x.Nodes).WithOne(x => x.Tree);
    }
}