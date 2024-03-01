using Ardalis.Specification;
using UserTree.Domain.Entities;

namespace UserTree.Application.Specifications;

public sealed class GetTreeNodeWithChildrenSpecification: Specification<TreeNode>
{
    public GetTreeNodeWithChildrenSpecification(int nodeId)
    {
        Query.Where(x => x.Id == nodeId).Include(x => x.ChildrenNodes).Include(x => x.Tree);
    }
}