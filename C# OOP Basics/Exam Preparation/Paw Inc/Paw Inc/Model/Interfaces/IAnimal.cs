using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum CleansingStatus { Uncleansed, Cleansed}
public interface IAnimal
{
    string Name { get; }
    int Age { get; }
    CleansingStatus CleansingStatus { get; }
    string AdoptionCenter { get; }
}