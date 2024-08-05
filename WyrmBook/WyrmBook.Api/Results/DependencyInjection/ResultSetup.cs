using FluentResults;
using WyrmBook.Api.Results.Errors;
using WyrmBook.Core.Exceptions;

namespace WyrmBook.Api.Results.DependencyInjection;

public static class ResultSetup
{
    public static void Setup()
    {
        Result.Setup(cfg =>
        {
            cfg.DefaultTryCatchHandler = exception => exception switch
            {
                DomainException domainException => new DomainExceptionError(domainException),
                NotFoundException notFoundException => new NotFoundError(notFoundException),
                _ => new UnexpectedError(exception)
            };
        });
    }
}