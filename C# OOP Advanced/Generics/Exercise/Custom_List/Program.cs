using System;

class Program
{
    static void Main(string[] args)
    {
        var list = new CustomList<string>();

        var input = "";
        while ((input = Console.ReadLine()) != "END")
        {
            var data = input.Split();
            var command = data[0];

            switch (command)
            {
                case "Add":
                    list.Add(data[1]);
                    break;

                case "Remove":
                    list.Remove(int.Parse(data[1]));
                    break;

                case "Contains":
                    System.Console.WriteLine(list.Contains(data[1]));
                    break;

                case "Swap":
                    var index1 = int.Parse(data[1]);
                    var index2 = int.Parse(data[2]);
                    list.Swap(index1, index2);
                    break;

                case "Greater":
                    System.Console.WriteLine(list.CountGreaterThan(data[1]));
                    break;
                
                case "Max":
                    System.Console.WriteLine(list.Max());
                    break;
                
                case "Min":
                    System.Console.WriteLine(list.Min());
                    break;

                case "Sort":
                    //The task says to make a method that sorts only this kind of list so...
                    list = Sorter.Sort<CustomList<string>, string>(list);
                    break;
                
                case "Print":
                    System.Console.WriteLine(string.Join(Environment.NewLine, list));
                    break;
            }
        }
    }
}