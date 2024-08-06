using MediatR;
using Microsoft.AspNetCore.Mvc;
using WyrmBook.Core.Models;
using WyrmBook.UseCases.Dragons.Commands.Create;
using WyrmBook.UseCases.Dragons.Commands.Delete;
using WyrmBook.UseCases.Dragons.Commands.Update;
using WyrmBook.UseCases.Dragons.Queries.GetAll;
using WyrmBook.UseCases.Dragons.Queries.GetByName;

namespace WyrmBook.Api.Controllers;

/// <summary>
///     Controller for Dragons
/// </summary>
[Route("api/[controller]")]
public class DragonsController(IMediator mediator) : BaseController(mediator)
{
    /// <summary>
    ///     Endpoint returning dragon by given <paramref name="name" />
    /// </summary>
    /// <param name="name">name to search by</param>
    [HttpGet("{name}")]
    public async Task<ActionResult<DragonModel>> GetDragon(string name)
    {
        return await Handle(new GetDragonByNameQuery(name));
    }

    /// <summary>
    ///     Endpoint returning all dragons
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DragonModel>>> GetAllDragons()
    {
        return await Handle(new GetAllDragonsQuery());
    }

    /// <summary>
    ///     Endpoint for creating a dragon entity of given <paramref name="dragon" />
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<DragonModel>> CreateDragon(DragonModel dragon)
    {
        return await Handle(new CreateDragonCommand(dragon));
    }

    /// <summary>
    ///     Endpoint for updating dragon entity of given <paramref name="dragon" />
    /// </summary>
    [HttpPut]
    public async Task<ActionResult<DragonModel>> UpdateDragon(DragonModel dragon)
    {
        return await Handle(new UpdateDragonCommand(dragon));
    }

    /// <summary>
    ///     Endpoint for deleting dragon with given <paramref name="name" />
    /// </summary>
    [HttpDelete("{name}")]
    public async Task<ActionResult> DeleteDragon(string name)
    {
        return await Handle(new DeleteDragonCommand(name));
    }
}