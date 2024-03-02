using FluentValidation;

namespace UserTree.Application.Trees.Queries.GetTreeQuery;

public class GetTreeQueryValidation : AbstractValidator<GetTreeQuery>
{
    public GetTreeQueryValidation()
    {
        RuleFor(x => x.TreeName).NotEmpty().NotNull().WithMessage("The treeName field is required.");
    }
}