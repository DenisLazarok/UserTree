using UserTree.Application.Specifications;
using UserTree.Domain.Entities;
using UserTree.Domain.Exceptions;
using UserTree.Domain.Interfaces;
using UserTree.Domain.Services;

namespace UserTree.Application.Services;

public class TreeNodeValidator : ITreeNodeValidator
{
    public void ValidateTreeNode(TreeNode? node, string treeName, int nodeId)
    {
        if (node is null)
            throw new SecureException($"Node with ID = {nodeId} was not found");
        
        if (node.Tree.Name != treeName)
            throw new SecureException($"Requested node was found, but it doesn't belong your tree");
    }
}