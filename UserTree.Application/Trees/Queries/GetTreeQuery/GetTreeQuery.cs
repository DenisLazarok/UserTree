using MediatR;

namespace UserTree.Application.Trees.Queries.GetTreeQuery;

public class GetTreeQuery : IRequest<string>
{
    public string TreeName { get; set; }
}