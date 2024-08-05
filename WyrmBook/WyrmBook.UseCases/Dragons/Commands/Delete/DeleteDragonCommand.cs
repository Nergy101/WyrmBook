using MediatR;

namespace WyrmBook.UseCases.Dragons.Commands.Delete;

/// <inheritdoc />
public record DeleteDragonCommand(string Name) : IRequest
{
}