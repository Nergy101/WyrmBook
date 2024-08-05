using WyrmBook.Core.Models;

namespace WyrmBook.Core.Interfaces;

/// <summary>
///     Interface for CRUD of Dragons
/// </summary>
public interface IDragonService
{
    /// <summary>
    ///     Creates a Dragon entity by given model
    /// </summary>
    /// <param name="dragon"></param>
    /// <returns></returns>
    DragonModel CreateDragon(DragonModel dragon);

    /// <summary>
    ///     Returns a DragonModel by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns>Dragon with given name</returns>
    DragonModel GetDragon(string name);

    /// <summary>
    ///     Updates dragon entity with model data, matched by name
    /// </summary>
    /// <param name="dragon"></param>
    void UpdateDragon(DragonModel dragon);

    /// <summary>
    ///     Delete dragon entity by given name
    /// </summary>
    /// <param name="name"></param>
    void DeleteDragon(string name);

    /// <summary>
    ///     Returns all dragons
    /// </summary>
    /// <returns>All dragons as enumerable</returns>
    IEnumerable<DragonModel> GetAllDragons();
}