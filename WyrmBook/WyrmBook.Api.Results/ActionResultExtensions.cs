using FluentResults;
using Microsoft.AspNetCore.Mvc;
using WyrmBook.Api.Results.Errors;
using WyrmBook.Api.Results.Models;

namespace WyrmBook.Api.Results;

public static class ActionResultExtensions
{
    public static ActionResult HandleResult<T>(this Result<T?> result)
    {
        return result switch
        {
            { IsFailed: true } when result.Errors.Any(e => e is DomainExceptionError)
                => CreateResult(result, 500),
            { IsFailed: true } when result.Errors.Any(e => e is UnexpectedError)
                => CreateResult(result, 500),
            { IsFailed: true } when result.Errors.Any(e => e is NotFoundError)
                => CreateResult(result, 404),
            { IsSuccess: true }
                => CreateResult(result, 200),
            _ => CreateResult(Result.Fail<T>("This error should never happen")!, 500)
        };
    }

    public static ActionResult HandleResult(this Result result)
    {
        return result switch
        {
            { IsFailed: true } when result.Errors.Any(e => e is DomainExceptionError)
                => CreateResult(result, 500),
            { IsFailed: true } when result.Errors.Any(e => e is UnexpectedError)
                => CreateResult(result, 500),
            { IsFailed: true } when result.Errors.Any(e => e is NotFoundError)
                => CreateResult(result, 404),
            { IsSuccess: true }
                => CreateResult(result, 200),
            _ => CreateResult(Result.Fail("This error should never happen")!, 500)
        };
    }

    private static ObjectResult CreateResult<T>(Result<T?> result, int statusCode)
    {
        return new ObjectResult(MapResultWithValue(result))
        {
            StatusCode = statusCode
        };
    }

    private static ObjectResult CreateResult(Result result, int statusCode)
    {
        return new ObjectResult(MapResult(result))
        {
            StatusCode = statusCode
        };
    }

    private static ValueResultResponseModel<T> MapResultWithValue<T>(Result<T?> result)
    {
        return new ValueResultResponseModel<T>(result.IsSuccess, result.ValueOrDefault,
            result.Errors.ConvertAll(x => x.ToString()));
    }

    private static VoidResultResponseModel MapResult(Result result)
    {
        return new VoidResultResponseModel(result.IsSuccess,
            result.Errors.ConvertAll(x => x.ToString()));
    }
}