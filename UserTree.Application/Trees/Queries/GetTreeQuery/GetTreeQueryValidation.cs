using FluentValidation;

namespace UserTree.Application.Trees.Queries.GetTreeQuery;

public class GetTreeQueryValidation : AbstractValidator<Trees.Queries.GetTreeQuery.GetTreeQuery>
{
    public GetTreeQueryValidation()
    {
    }
}