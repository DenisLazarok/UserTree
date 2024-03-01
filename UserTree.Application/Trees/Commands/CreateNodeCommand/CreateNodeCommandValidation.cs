using FluentValidation;

namespace UserTree.Application.Trees.Commands.CreateNodeCommand;

public class CreateNodeCommandValidation : AbstractValidator<CreateNodeCommand>
{
    public CreateNodeCommandValidation()
    {
        RuleFor(x => x.NodeName).NotEmpty().NotNull().WithMessage("The nodeName field is required.");
    }
}