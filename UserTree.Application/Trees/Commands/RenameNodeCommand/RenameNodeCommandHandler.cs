using MediatR;
using UserTree.Application.Specifications;
using UserTree.Domain.Entities;
using UserTree.Domain.Interfaces;
using UserTree.Domain.Services;

namespace UserTree.Application.Trees.Commands.RenameNodeCommand;

public class RenameNodeCommandHandler : IRequestHandler<RenameNodeCommand>
{
    private readonly IRepository<TreeNode> _treeNodeRepository;
    private readonly ITreeNodeValidator _treeNodeValidator;

    public RenameNodeCommandHandler(IRepository<TreeNode> treeNodeRepository, ITreeNodeValidator treeNodeValidator)
    {
        _treeNodeRepository = treeNodeRepository;
        _treeNodeValidator = treeNodeValidator;
    }
    
    public async Task Handle(RenameNodeCommand request, CancellationToken cancellationToken)
    {
        var node = await _treeNodeRepository.GetByIdAsync(new GetTreeNodeSpecification(request.NodeId), cancellationToken);
        _treeNodeValidator.ValidateTreeNode(node, request.TreeName, request.NodeId);

        if (node!.ParentNode is null)
            throw new Exception($"Couldn't rename root node");
        
        node.Name = request.NewNodeName;
        await _treeNodeRepository.SaveChangesAsync(cancellationToken);
    }
}