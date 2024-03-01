namespace UserTree.Domain.Entities;

public class Tree
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<TreeNode> Nodes { get; set; }

    public Tree(string name)
    {
        Name = name;
    }

    public TreeNode? GetRoot() 
        => Nodes.FirstOrDefault(x => x.ParentNode is null);
}