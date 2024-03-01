using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserTree.Domain.Entities;
using UserTree.Infrastructure.Persistence.Base.Extensions;
using NvarcharLength = UserTree.Infrastructure.Persistence.Base.Extensions.NvarcharLength;

namespace UserTree.Infrastructure.Persistence.Configurations;

public class TreeNodeConfiguration : IEntityTypeConfiguration<TreeNode>
{
    public void Configure(EntityTypeBuilder<TreeNode> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(NvarcharLength.Nvarchar2048);

        builder.HasMany(x => x.ChildrenNodes).WithOne(x => x.ParentNode);
    }
}