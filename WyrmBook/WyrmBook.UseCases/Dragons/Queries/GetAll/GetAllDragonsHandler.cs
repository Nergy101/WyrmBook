using MediatR;
using WyrmBook.Core.Models;
using WyrmBook.Core.Services;

namespace WyrmBook.UseCases.Dragons.Queries.GetAll;

/// <inheritdoc />
public class GetAllDragonsHandler(DragonService dragonService)
    : IRequestHandler<GetAllDragonsQuery, IEnumerable<DragonModel>>
{
    /// <inheritdoc />
    public Task<IEnumerable<DragonModel>> Handle(GetAllDragonsQuery request, CancellationToken cancellationToken)
    {
        var dragons = dragonService.GetAllDragons();
        return Task.FromResult(dragons);
    }
}