using MediatR;
using WyrmBook.Core.Models;
using WyrmBook.Core.Services;

namespace WyrmBook.UseCases.Dragons.Commands.Create;

/// <inheritdoc />
public class CreateDragonHandler(DragonService dragonService) : IRequestHandler<CreateDragonCommand, DragonModel>
{
    /// <inheritdoc />
    public Task<DragonModel> Handle(CreateDragonCommand request, CancellationToken cancellationToken)
    {
        dragonService.CreateDragon(request.Dragon);
        return Task.FromResult(request.Dragon);
    }
}