using FluentValidation;

namespace UserTree.Application.Trees.Commands.RenameNodeCommand;

public class RenameNodeCommandValidation : AbstractValidator<RenameNodeCommand>
{
    public RenameNodeCommandValidation()
    {
        RuleFor(x => x.TreeName).NotEmpty().NotNull().WithMessage("The treeName field is required.");
        RuleFor(x => x.NewNodeName).NotEmpty().NotNull().WithMessage("The newNodeName field is required.");
        RuleFor(x => x.NodeId).GreaterThan(0).NotNull().WithMessage("The parentNodeId field is required and should me more than 0.");
    }
}