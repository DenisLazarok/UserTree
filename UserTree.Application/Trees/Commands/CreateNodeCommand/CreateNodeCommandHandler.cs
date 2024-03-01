using MediatR;
using UserTree.Application.Specifications;
using UserTree.Domain.Entities;
using UserTree.Domain.Interfaces;
using UserTree.Domain.Services;

namespace UserTree.Application.Trees.Commands.CreateNodeCommand;

public class CreateNodeCommandHandler : IRequestHandler<CreateNodeCommand>
{
    private readonly IRepository<TreeNode> _treeNodeRepository;
    private readonly ITreeNodeValidator _treeNodeValidator;

    public CreateNodeCommandHandler(IRepository<TreeNode> treeNodeRepository, ITreeNodeValidator treeNodeValidator)
    {
        _treeNodeRepository = treeNodeRepository;
        _treeNodeValidator = treeNodeValidator;
    }

    public async Task Handle(CreateNodeCommand request, CancellationToken cancellationToken)
    {
        var parentNode = await _treeNodeRepository.FirstOrDefaultAsync(new GetTreeNodeWithChildrenSpecification(request.ParentNodeId), cancellationToken);
        
        _treeNodeValidator.ValidateTreeNode(parentNode, request.TreeName, request.ParentNodeId);

        if (parentNode!.ChildrenNodes.Any(x => x.Name == request.NodeName))
            throw new Exception($"Duplicate name");

        parentNode.ChildrenNodes.Add(new TreeNode(request.NodeName, parentNode.Tree));
        await _treeNodeRepository.SaveChangesAsync(cancellationToken);
    }
}