using MediatR;

namespace UserTree.Application.Trees.Commands.DeleteNodeCommand;

public class DeleteNodeCommand : IRequest
{
    public string TreeName { get; set; }
    public int NodeId { get; set; }
}