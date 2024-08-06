enum ElementalType {
  // Define the enum values according to WyrmBook.Domain.Enums.ElementalType
  // Example:
  Fire,
  Water,
  Earth,
  Air,
}

enum DragonSubType {
  // Define the enum values according to WyrmBook.Domain.Enums.DragonSubType
  // Example:
  Western,
  Eastern,
  Wyvern,
  Drake,
}

interface Dragon {
  /**
   * Mystical age of the dragon
   */
  age: number;

  /**
   * Mystical name of the dragon
   */
  name: string;

  /**
   * Mystical dragon elemental type
   */
  elementalType: ElementalType;

  /**
   * Mystical dragon subtype
   */
  subType: DragonSubType;

  /**
   * Amount of legs the dragon-type has
   */
  amountOfLegs: number;

  /**
   * Amount of wings the dragon-type has
   */
  amountOfWings: number;
}

export { Dragon, ElementalType, DragonSubType };
