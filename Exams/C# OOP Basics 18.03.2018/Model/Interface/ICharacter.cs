using System;
using System.Collections.Generic;
using System.Text;

public enum Faction {CSharp, Java }
public interface ICharacter
{
    string Name { get; }
    double BaseHealth { get; }
    double Health { get; }
    double BaseArmor { get; }
    double Armor { get; }
    double AbilityPoints { get; }
    Bag Bag { get; }
    Faction Faction { get; }
    bool IsAlive { get; }

    void TakeDamage(double hitPoints);
    void Rest();
    void UseItem(Item item);
    void UseItemOn(Item item, Character character);
    void GiveCharacterItem(Item item, Character character);
    void ReceiveItem(Item item);

    //Personal methods
    void IncreaseHealth(double amount);
    void DecreaseHealth(double amount);
    void RepairArmor();
}