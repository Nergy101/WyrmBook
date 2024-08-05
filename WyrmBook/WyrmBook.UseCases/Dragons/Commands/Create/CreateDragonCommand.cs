using MediatR;
using WyrmBook.Core.Models;

namespace WyrmBook.UseCases.Dragons.Commands.Create;

/// <inheritdoc />
public record CreateDragonCommand(DragonModel Dragon) : IRequest<DragonModel>
{
}