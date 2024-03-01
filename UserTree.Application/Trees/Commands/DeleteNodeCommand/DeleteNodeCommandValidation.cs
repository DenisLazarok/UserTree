using FluentValidation;

namespace UserTree.Application.Trees.Commands.DeleteNodeCommand;

public class DeleteNodeCommandValidation : AbstractValidator<DeleteNodeCommand>
{
    public DeleteNodeCommandValidation()
    {
    }
}