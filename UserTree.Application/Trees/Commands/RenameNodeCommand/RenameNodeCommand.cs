using MediatR;

namespace UserTree.Application.Trees.Commands.RenameNodeCommand;

public class RenameNodeCommand : IRequest
{
    public string TreeName { get; set; }
    public int NodeId { get; set; }
    public string NewNodeName { get; set; }
}