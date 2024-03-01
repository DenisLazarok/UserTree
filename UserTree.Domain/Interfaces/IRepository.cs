using Ardalis.Specification;

namespace UserTree.Domain.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
}