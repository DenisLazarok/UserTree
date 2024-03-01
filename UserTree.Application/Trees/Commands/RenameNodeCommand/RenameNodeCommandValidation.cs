using FluentValidation;

namespace UserTree.Application.Trees.Commands.RenameNodeCommand;

public class RenameNodeCommandValidation : AbstractValidator<RenameNodeCommand>
{
    public RenameNodeCommandValidation()
    {
    }
}