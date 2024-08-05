using MediatR;
using WyrmBook.Core.Models;

namespace WyrmBook.UseCases.Dragons.Queries.GetByName;

/// <inheritdoc />
public record GetDragonByNameQuery(string Name) : IRequest<DragonModel>
{
}