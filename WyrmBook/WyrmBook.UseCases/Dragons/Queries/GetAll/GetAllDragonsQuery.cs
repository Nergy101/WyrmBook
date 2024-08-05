using MediatR;
using WyrmBook.Core.Models;

namespace WyrmBook.UseCases.Dragons.Queries.GetAll;

/// <inheritdoc />
public record GetAllDragonsQuery : IRequest<IEnumerable<DragonModel>>
{
}