using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WyrmBook.Api.Results;

namespace WyrmBook.Api.Controllers;

/// <summary>
///     Controller base with generic Handle by MediatR
/// </summary>
public class BaseController(IMediator mediator) : Controller
{
    /// <summary>
    ///     Handle given <paramref name="request" /> by mediatr and handle the result
    /// </summary>
    /// <param name="request">The command or query to handle</param>
    /// <typeparam name="T">Type of the request -command or -query</typeparam>
    /// <returns>
    ///     An <see cref="ActionResult" /> based on the request's <see cref="Result" /> or <see cref="Result{T}" />
    ///     in a standardized format for client consumption
    /// </returns>
    protected async Task<ActionResult> Handle<T>(T request)
    {
        var result = await Result.Try(() => mediator.Send(request!));
        return result!.HandleResult();
    }
}