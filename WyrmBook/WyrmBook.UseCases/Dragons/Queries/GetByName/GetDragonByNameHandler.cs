using MediatR;
using WyrmBook.Core.Models;
using WyrmBook.Core.Services;

namespace WyrmBook.UseCases.Dragons.Queries.GetByName;

/// <inheritdoc />
public class GetDragonByNameHandler(DragonService dragonService) : IRequestHandler<GetDragonByNameQuery, DragonModel>
{
    /// <inheritdoc />
    public Task<DragonModel> Handle(GetDragonByNameQuery request, CancellationToken cancellationToken)
    {
        var dragon = dragonService.GetDragon(request.Name);
        return Task.FromResult(dragon);
    }
}