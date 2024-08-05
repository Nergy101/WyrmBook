using FluentResults;

namespace WyrmBook.Api.Results.Errors;

/// <inheritdoc />
public class NotFoundError(Exception innerException) : Error
{
    public override string ToString()
    {
        return $"{innerException.GetType()}: {innerException.Message}";
    }
}