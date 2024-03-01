using MediatR;

namespace UserTree.Application.Trees.Commands.CreateNodeCommand;

public class CreateNodeCommand : IRequest
{
    public string TreeName { get; set; }
    public int ParentNodeId  { get; set; }
    public string NodeName  { get; set; }
}