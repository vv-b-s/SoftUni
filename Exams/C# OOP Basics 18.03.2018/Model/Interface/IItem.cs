using System;
using System.Collections.Generic;
using System.Text;

public interface IItem
{
    int Weight { get; }

    void AffectCharacter(Character character);
}