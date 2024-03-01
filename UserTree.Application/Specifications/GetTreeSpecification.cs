using Ardalis.Specification;
using UserTree.Domain.Entities;

namespace UserTree.Application.Specifications;

public sealed class GetTreeSpecification : Specification<Tree>
{
    public GetTreeSpecification(string name)
    {
        Query.Where(x => x.Name == name).Include(x => x.Nodes);
    }
}