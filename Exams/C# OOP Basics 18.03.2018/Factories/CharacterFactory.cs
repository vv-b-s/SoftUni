using System;
using System.Collections.Generic;
using System.Text;

public class CharacterFactory
{
    public static Character CreateCharacter(string faction, string characterType, string name)
    {
        if (!Enum.TryParse(faction, out Faction parsedFaction))
            throw new ArgumentException($"Invalid faction \"{faction}\"!");

        if (characterType != "Warrior" && characterType != "Cleric")
            throw new ArgumentException($"Invalid character type \"{characterType}\"!");

        var character = Activator.CreateInstance(Type.GetType(characterType), name, parsedFaction) as Character;

        return character;
    }
}