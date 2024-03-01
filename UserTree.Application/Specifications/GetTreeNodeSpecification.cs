using Ardalis.Specification;
using UserTree.Domain.Entities;

namespace UserTree.Application.Specifications;

public sealed class GetTreeNodeSpecification: Specification<TreeNode>
{
    public GetTreeNodeSpecification(int nodeId)
    {
        Query.Where(x => x.Id == nodeId).Include(x => x.Tree);
    }
}