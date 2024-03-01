using Ardalis.Specification;
using UserTree.Domain.Entities;

namespace UserTree.Application.Specifications;

public sealed class GetTreeNodeChildrenSpecification: Specification<TreeNode>
{
    public GetTreeNodeChildrenSpecification(int nodeId)
    {
        Query.Where(x => x.ParentNodeId == nodeId);
    }
}