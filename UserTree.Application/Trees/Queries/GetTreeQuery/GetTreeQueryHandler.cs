using System.Text.Json;
using MediatR;
using UserTree.Application.Specifications;
using UserTree.Domain.Entities;
using UserTree.Domain.Interfaces;

namespace UserTree.Application.Trees.Queries.GetTreeQuery;

public class GetTreeQueryHandler : IRequestHandler<GetTreeQuery, string>
{
    private readonly IRepository<Tree> _treeRepository;

    public GetTreeQueryHandler(IRepository<Tree> treeRepository)
    {
        _treeRepository = treeRepository;
    }

    public async Task<string> Handle(GetTreeQuery request, CancellationToken cancellationToken)
    {
        var tree = await _treeRepository.FirstOrDefaultAsync(new GetTreeSpecification(request.TreeName), cancellationToken);

        if (tree is not null)
        {
            return JsonSerializer.Serialize(tree.GetRoot());
        }

        var newTree = new Tree(request.TreeName);

        await _treeRepository.AddAsync(newTree, cancellationToken);

        await _treeRepository.SaveChangesAsync(cancellationToken);
        
        return JsonSerializer.Serialize(newTree.GetRoot());
    }
}