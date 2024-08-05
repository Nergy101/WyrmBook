using WyrmBook.Domain.Enums;

namespace WyrmBook.Domain.Entities;

/// <summary>
///     Behold, a Dragon!
/// </summary>
public class Dragon
{
    /// <summary>
    ///     Mystical age of the dragon
    /// </summary>
    public required int Age { get; init; }

    /// <summary>
    ///     Mystical name of the dragon
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    ///     Mystical dragon elemental type
    /// </summary>
    public required ElementalType ElementalType { get; init; }

    /// <summary>
    ///     Mystical dragon subtype
    /// </summary>
    public required DragonSubType SubType { get; init; }

    /// <summary>
    ///     Amount of legs the dragon-type has
    /// </summary>
    public required int AmountOfLegs { get; init; }

    /// <summary>
    ///     Amount of wings the dragon-type has
    /// </summary>
    public required int AmountOfWings { get; init; }
}