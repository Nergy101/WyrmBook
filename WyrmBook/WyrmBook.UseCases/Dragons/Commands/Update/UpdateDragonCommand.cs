using MediatR;
using WyrmBook.Core.Models;

namespace WyrmBook.UseCases.Dragons.Commands.Update;

/// <inheritdoc />
public record UpdateDragonCommand(DragonModel Dragon) : IRequest<DragonModel>
{
}