using System.Reflection;
using Microsoft.EntityFrameworkCore;
using UserTree.Domain.Entities;

namespace UserTree.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Tree> Trees { get; set; }
    public DbSet<TreeNode> TreeNodes { get; set; }
    public DbSet<JournalEvent> JournalEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}