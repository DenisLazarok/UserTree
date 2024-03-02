using FluentValidation;

namespace UserTree.Application.Trees.Commands.CreateNodeCommand;

public class CreateNodeCommandValidation : AbstractValidator<CreateNodeCommand>
{
    public CreateNodeCommandValidation()
    {
        RuleFor(x => x.NodeName).NotEmpty().NotNull().WithMessage("The nodeName field is required.");
        RuleFor(x => x.ParentNodeId).GreaterThan(0).NotNull().WithMessage("The parentNodeId field is required and should me more than 0.");
        RuleFor(x => x.TreeName).NotEmpty().NotNull().WithMessage("The treeName field is required.");
    }
}