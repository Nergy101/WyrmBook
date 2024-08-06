using WyrmBook.Core.Exceptions;
using WyrmBook.Core.Interfaces;
using WyrmBook.Core.Models;
using WyrmBook.Domain.Entities;
using WyrmBook.Domain.Enums;

namespace WyrmBook.Core.Services;

/// <inheritdoc cref="IDragonService" />
public class DragonService : IDragonService
{
    private readonly Dictionary<string, Dragon> _dragons = new()
    {
          { "Smaug", new Dragon 
                {
                    Age = 180,
                    Name = "Smaug",
                    ElementalType = ElementalType.Fire,
                    SubType = DragonSubType.Wyrm,
                    AmountOfLegs = 4,
                    AmountOfWings = 2
                }
            },
            { "Drogon", new Dragon 
                {
                    Age = 7,
                    Name = "Drogon",
                    ElementalType = ElementalType.Fire,
                    SubType = DragonSubType.Wyvern,
                    AmountOfLegs = 2,
                    AmountOfWings = 2
                }
            },
            { "Toothless", new Dragon 
                {
                    Age = 21,
                    Name = "Toothless",
                    ElementalType = ElementalType.Unknown,
                    SubType = DragonSubType.Dragon,
                    AmountOfLegs = 2,
                    AmountOfWings = 2
                }
            },
            { "Falkor", new Dragon 
                {
                    Age = 120,
                    Name = "Falkor",
                    ElementalType = ElementalType.Unknown,
                    SubType = DragonSubType.Dragon,
                    AmountOfLegs = 4,
                    AmountOfWings = 0
                }
            },
            { "Alduin", new Dragon 
                {
                    Age = 5000,
                    Name = "Alduin",
                    ElementalType = ElementalType.Fire,
                    SubType = DragonSubType.Dragon,
                    AmountOfLegs = 4,
                    AmountOfWings = 2
                }
            },
            { "Shenron", new Dragon 
                {
                    Age = 2000,
                    Name = "Shenron",
                    ElementalType = ElementalType.Unknown,
                    SubType = DragonSubType.Dragon,
                    AmountOfLegs = 4,
                    AmountOfWings = 0
                }
            },
            { "Charizard", new Dragon 
                {
                    Age = 10,
                    Name = "Charizard",
                    ElementalType = ElementalType.Fire,
                    SubType = DragonSubType.Dragon,
                    AmountOfLegs = 2,
                    AmountOfWings = 2
                }
            },
            { "Saphira", new Dragon 
                {
                    Age = 5,
                    Name = "Saphira",
                    ElementalType = ElementalType.Water,
                    SubType = DragonSubType.Dragon,
                    AmountOfLegs = 4,
                    AmountOfWings = 2
                }
            },
            { "Norbert", new Dragon 
                {
                    Age = 1,
                    Name = "Norbert",
                    ElementalType = ElementalType.Fire,
                    SubType = DragonSubType.Dragon,
                    AmountOfLegs = 4,
                    AmountOfWings = 2
                }
            },
            { "Draco", new Dragon 
                {
                    Age = 1000,
                    Name = "Draco",
                    ElementalType = ElementalType.Fire,
                    SubType = DragonSubType.Dragon,
                    AmountOfLegs = 4,
                    AmountOfWings = 2
                }
            }
    };

    /// <inheritdoc />
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="DomainException"></exception>
    public DragonModel CreateDragon(DragonModel dragon)
    {
        if (dragon == null) throw new ArgumentNullException(nameof(dragon), "DragonModel cannot be null");

        if (!_dragons.TryAdd(dragon.Name, Cast(dragon)))
            throw new DomainException($"Dragon with name {dragon.Name} already exists");

        return dragon;
    }

    /// <inheritdoc />
    /// <exception cref="NotFoundException"></exception>
    public DragonModel GetDragon(string name)
    {
        if (_dragons.TryGetValue(name, out var dragon)) return Cast(dragon);

        throw new NotFoundException($"Dragon with name {name} not found");
    }

    /// <inheritdoc />
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotFoundException"></exception>
    public void UpdateDragon(DragonModel dragon)
    {
        if (dragon == null) throw new ArgumentNullException(nameof(dragon), "Dragon cannot be null");

        if (!_dragons.ContainsKey(dragon.Name))
            throw new NotFoundException($"Dragon with name {dragon.Name} not found");

        _dragons[dragon.Name] = Cast(dragon);
    }

    /// <inheritdoc />
    /// <exception cref="NotFoundException"></exception>
    public void DeleteDragon(string name)
    {
        if (!_dragons.Remove(name)) throw new NotFoundException($"Dragon with name {name} not found");
    }


    /// <inheritdoc />
    public IEnumerable<DragonModel> GetAllDragons()
    {
        return _dragons.Values.Select(Cast);
    }

    private static DragonModel Cast(Dragon dragon)
    {
        return new DragonModel
        {
            Name = dragon.Name,
            SubType = dragon.SubType,
            ElementalType = dragon.ElementalType,
            Age = dragon.Age
        };
    }


    private static Dragon Cast(DragonModel dragon)
    {
        return new Dragon
        {
            Name = dragon.Name,
            ElementalType = dragon.ElementalType,
            SubType = dragon.SubType,
            AmountOfLegs = dragon.SubType switch
            {
                DragonSubType.Dragon => 4,
                DragonSubType.Drake => 4,
                DragonSubType.Wyvern => 2,
                DragonSubType.Wyrm => 0,
                _ => 0
            },
            AmountOfWings = dragon.SubType switch
            {
                DragonSubType.Dragon => 2,
                DragonSubType.Drake => 0,
                DragonSubType.Wyvern => 2,
                DragonSubType.Wyrm => 0,
                _ => 0
            },
            Age = dragon.Age
        };
    }
}