using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DungeonMaster
{
    private Dictionary<string, Character> party;

    private Stack<Item> itemPool;
    private int roundsWithNoChanges;

    public DungeonMaster()
    {
        party = new Dictionary<string, Character>();
        itemPool = new Stack<Item>();
    }

    public string JoinParty(string[] args)
    {
        var faction = args[0];
        var characterType = args[1];
        var name = args[2];

        var character = CharacterFactory.CreateCharacter(faction, characterType, name);

        this.party[name] = character;

        return $"{name} joined the party!";
    }

    public string AddItemToPool(string[] args)
    {
        var item = ItemFactory.CreateItem(args[0]);

        this.itemPool.Push(item);

        return $"{args[0]} added to pool.";
    }

    public string PickUpItem(string[] args)
    {
        var characterName = args[0];
        var character = GetCharacter(characterName);

        if (itemPool.Count > 0)
        {
            var item = this.itemPool.Pop();
            character.ReceiveItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }
        else throw new InvalidOperationException("No items left in pool!");        
    }

    public string UseItem(string[] args)
    {
        var characterName = args[0];
        var itemName = args[1];

        var character = GetCharacter(characterName);
        var item = character.Bag.GetItem(itemName);

        character.UseItem(item);

        return $"{characterName} used {itemName}.";
    }

    public string UseItemOn(string[] args)
    {
        var giverName = args[0];
        var receiverName = args[1];
        var itemName = args[2];

        var giver = GetCharacter(giverName);
        var receiver = GetCharacter(receiverName);

        var item = giver.Bag.GetItem(itemName);

        giver.UseItemOn(item, receiver);

        return $"{giverName} used {itemName} on {receiverName}.";
    }

    public string GiveCharacterItem(string[] args)
    {
        var giverName = args[0];
        var receiverName = args[1];
        var itemName = args[2];

        var giver = GetCharacter(giverName);
        var receiver = GetCharacter(receiverName);

        var item = giver.Bag.GetItem(itemName);

        giver.GiveCharacterItem(item, receiver);

        return $"{giverName} gave {receiverName} {itemName}.";
    }

    public string GetStats()
    {
        var characters = this.party.Values
            .OrderByDescending(c => c.IsAlive)
            .ThenByDescending(c => c.Health);

        return string.Join(Environment.NewLine, characters);
    }

    public string Attack(string[] args)
    {
        var attackerName = args[0];
        var receiverName = args[1];

        var attacker = GetCharacter(attackerName);
        var receiver = GetCharacter(receiverName);

        if (attacker is Warrior)
        {
            ((Warrior)attacker).Attack(receiver);

            var output = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (!receiver.IsAlive)
                output += Environment.NewLine + $"{receiverName} is dead!";

            return output;
        }
        else throw new ArgumentException($"{ attacker.Name } cannot attack!");
    }

    public string Heal(string[] args)
    {
        var healerName = args[0];
        var healingReceiverName = args[1];

        var healer = GetCharacter(healerName);
        var receiver = GetCharacter(healingReceiverName);

        if (healer is Cleric)
        {
            ((Cleric)healer).Heal(receiver);

            var output = $"{ healer.Name } heals { receiver.Name} for { healer.AbilityPoints}! { receiver.Name} has { receiver.Health} health now!";
            return output;
        }
        else throw new ArgumentException($"{healerName} cannot heal!");
    }

    public string EndTurn(string[] args)
    {
        var output = new List<string>();
        var survivorCount = 0;

        foreach (var character in this.party.Values)
        {
            if (character.IsAlive)
            {
                var healthBefore = character.Health;
                character.Rest();
                output.Add($"{character.Name} rests ({healthBefore} => {character.Health})");

                survivorCount++;
            }
        }

        if (survivorCount <= 1)
            this.roundsWithNoChanges++;

        return string.Join(Environment.NewLine, output);
    }

    public bool IsGameOver()
    {
        var surviversCount = this.party.Count(c => c.Value.IsAlive);

        return roundsWithNoChanges > 1 || surviversCount == 0;
    }

    private Character GetCharacter(string characterName)
    {
        if (this.party.ContainsKey(characterName))
            return this.party[characterName];

        else throw new ArgumentException($"Character {characterName} not found!");
    }

}
