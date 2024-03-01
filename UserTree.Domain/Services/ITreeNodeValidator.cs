using UserTree.Domain.Entities;

namespace UserTree.Domain.Services;

public interface ITreeNodeValidator
{
    void ValidateTreeNode(TreeNode? node, string treeName, int nodeId);
}