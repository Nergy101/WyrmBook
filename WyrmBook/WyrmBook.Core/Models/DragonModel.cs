using WyrmBook.Domain.Entities;
using WyrmBook.Domain.Enums;

namespace WyrmBook.Core.Models;

public record DragonModel
{
    public required int Age { get; init; }
    public required string Name { get; init; }
    public required ElementalType ElementalType { get; init; }
    public required DragonSubType SubType { get; init; }
}