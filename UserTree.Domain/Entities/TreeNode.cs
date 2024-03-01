namespace UserTree.Domain.Entities;

public sealed class TreeNode
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentNodeId { get; set; }
    public TreeNode? ParentNode { get; set; }
    public List<TreeNode> ChildrenNodes { get; set; } = new List<TreeNode>();
    public Tree Tree { get; set; }
    
#pragma warning disable CS8618
    private TreeNode()
    {
        
    }
    
    public TreeNode(TreeNode? parentNode, string name, Tree tree)
    {
        ParentNode = parentNode;
        Name = name;
        Tree = tree;
    }
    public TreeNode(string name, Tree tree)
    {
        Name = name;
        Tree = tree;
    }
}