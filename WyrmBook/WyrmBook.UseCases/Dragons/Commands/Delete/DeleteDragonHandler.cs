using MediatR;
using WyrmBook.Core.Services;

namespace WyrmBook.UseCases.Dragons.Commands.Delete;

/// <inheritdoc />
public class DeleteDragonHandler(DragonService dragonService) : IRequestHandler<DeleteDragonCommand>
{
    /// <inheritdoc />
    public Task Handle(DeleteDragonCommand request, CancellationToken cancellationToken)
    {
        dragonService.DeleteDragon(request.Name);
        return Task.CompletedTask;
    }
}