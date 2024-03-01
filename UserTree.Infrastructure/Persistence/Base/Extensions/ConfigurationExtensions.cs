using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserTree.Infrastructure.Persistence.Base.Extensions;

internal static class ConfigurationExtensions
{
    public static PropertyBuilder<TProperty> HasMaxLength<TProperty>(this PropertyBuilder<TProperty> builder,
        NvarcharLength length)
    {
        builder.HasMaxLength((int)length);
        return builder;
    }
}

internal enum NvarcharLength
{
    Nvarchar2 = 2,
    Nvarchar4 = 4,
    Nvarchar8 = 8,
    Nvarchar16 = 16,
    Nvarchar32 = 32,
    Nvarchar64 = 64,
    Nvarchar128 = 128,
    Nvarchar256 = 256,
    Nvarchar512 = 512,
    Nvarchar1024 = 1024,
    Nvarchar2048 = 2048,
    Nvarchar4000 = 4000
}
