using FluentValidation;

namespace UserTree.Application.Trees.Commands.DeleteNodeCommand;

public class DeleteNodeCommandValidation : AbstractValidator<DeleteNodeCommand>
{
    public DeleteNodeCommandValidation()
    {
        RuleFor(x => x.TreeName).NotEmpty().NotNull().WithMessage("The treeName field is required.");
        RuleFor(x => x.NodeId).GreaterThan(0).NotNull().WithMessage("The parentNodeId field is required and should me more than 0.");
    }
}