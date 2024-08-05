using MediatR;
using WyrmBook.Core.Models;
using WyrmBook.Core.Services;

namespace WyrmBook.UseCases.Dragons.Commands.Update;

/// <inheritdoc />
public class UpdateDragonHandler(DragonService dragonService) : IRequestHandler<UpdateDragonCommand, DragonModel>
{
    /// <inheritdoc />
    public Task<DragonModel> Handle(UpdateDragonCommand request, CancellationToken cancellationToken)
    {
        dragonService.UpdateDragon(request.Dragon);
        return Task.FromResult(request.Dragon);
    }
}