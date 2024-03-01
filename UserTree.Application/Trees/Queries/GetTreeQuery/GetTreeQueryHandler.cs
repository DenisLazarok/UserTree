using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using MediatR;
using UserTree.Application.Extensions;
using UserTree.Application.Specifications;
using UserTree.Domain.Entities;
using UserTree.Domain.Interfaces;

namespace UserTree.Application.Trees.Queries.GetTreeQuery;

public class GetTreeQueryHandler : IRequestHandler<GetTreeQuery, string>
{
    private readonly IRepository<Tree> _treeRepository;
    private readonly IMapper _mapper;

    public GetTreeQueryHandler(IRepository<Tree> treeRepository, IMapper mapper)
    {
        _treeRepository = treeRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(GetTreeQuery request, CancellationToken cancellationToken)
    {
        var tree = await _treeRepository.FirstOrDefaultAsync(new GetTreeSpecification(request.TreeName), cancellationToken);

        if (tree is not null)
        {
            return GetResult(tree.GetRoot());
        }

        var newTree = new Tree(request.TreeName);
        newTree.Nodes.Add(new TreeNode(request.TreeName, newTree));

        await _treeRepository.AddAsync(newTree, cancellationToken);

        await _treeRepository.SaveChangesAsync(cancellationToken);
        
        return GetResult(newTree.GetRoot());
    }

    private string GetResult(TreeNode? root)
    {
        var rootNodeDto = _mapper.Map<TreeNodeDto>(root);
        return JsonSerializer.Serialize(rootNodeDto, options: new JsonSerializerOptions() {ReferenceHandler = ReferenceHandler.IgnoreCycles, WriteIndented = true});
    }

    public class TreeNodeDto : IMapFrom<TreeNode>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public List<TreeNodeDto> ChildrenNodes { get; set; } = new List<TreeNodeDto>();
    }
}