namespace UserTree.Domain.Entities;

public sealed class TreeNode
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentNodeId { get; set; }
    public TreeNode? ParentNode { get; set; }
    public List<TreeNode> ChildrenNodes { get; set; }
    public Tree Tree { get; set; }

    public TreeNode(TreeNode? parentNode, string name)
    {
        ParentNode = parentNode;
        Name = name;
    }
    public TreeNode(string name)
    {
        Name = name;
    }
}