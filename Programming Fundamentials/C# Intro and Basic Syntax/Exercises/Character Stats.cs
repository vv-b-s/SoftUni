using static System.Console;

class Program
{
    static void Main()
    {
        string name = ReadLine();
        int health = int.Parse(ReadLine());
        int maxHealth = int.Parse(ReadLine());
        int energy = int.Parse(ReadLine());
        int maxEnergy = int.Parse(ReadLine());

        WriteLine($"Name: {name}\n" +
            $"Health: |{new string('|', health)}{new string('.', maxHealth - health)}|\n" +
            $"Energy: |{new string('|',energy)}{new string('.',maxEnergy-energy)}|");
    }
}
