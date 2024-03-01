using MediatR;
using UserTree.Application.Specifications;
using UserTree.Domain.Entities;
using UserTree.Domain.Interfaces;
using UserTree.Domain.Services;

namespace UserTree.Application.Trees.Commands.DeleteNodeCommand;

public class DeleteNodeCommandHandler : IRequestHandler<DeleteNodeCommand>
{
    private readonly IRepository<TreeNode> _treeNodeRepository;
    private readonly IRepository<Tree> _treeRepository;
    private readonly ITreeNodeValidator _treeNodeValidator;

    public DeleteNodeCommandHandler(IRepository<TreeNode> treeNodeRepository, ITreeNodeValidator treeNodeValidator, IRepository<Tree> treeRepository)
    {
        _treeNodeRepository = treeNodeRepository;
        _treeNodeValidator = treeNodeValidator;
        _treeRepository = treeRepository;
    }

    public async Task Handle(DeleteNodeCommand request, CancellationToken cancellationToken)
    {
        var node = await _treeNodeRepository.FirstOrDefaultAsync(new GetTreeNodeSpecification(request.NodeId), cancellationToken);
        
        _treeNodeValidator.ValidateTreeNode(node, request.TreeName, request.NodeId);
        
        var hasChildNodes = await _treeNodeRepository.AnyAsync(new GetTreeNodeChildrenSpecification(request.NodeId), cancellationToken);
        
        if(hasChildNodes)
            throw new Exception($"You have to delete all children nodes first");

        await _treeNodeRepository.DeleteAsync(node!, cancellationToken);
        
        if (node!.ParentNode is null)
        {
            await _treeRepository.DeleteAsync(node.Tree, cancellationToken);
        }
        await _treeNodeRepository.SaveChangesAsync(cancellationToken);
    }
}