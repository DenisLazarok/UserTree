using Ardalis.Specification.EntityFrameworkCore;
using UserTree.Domain.Interfaces;

namespace UserTree.Infrastructure.Persistence.Base.GenericRepository;

public class Repository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity> where TEntity : class
{
    public Repository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}