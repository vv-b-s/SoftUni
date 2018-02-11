using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var targetsData = new Dictionary<string, Dictionary<string, string>>();

        var targetInfoIndex = int.Parse(ReadLine());

        var input = "";
        while((input=ReadLine())!="end transmissions")
        {
            var targetName = input.Split("=")[0];
            var targetKeysAndValues = input.Split("=")[1].Split(';');

            if (!targetsData.ContainsKey(targetName))
                targetsData[targetName] = new Dictionary<string, string>();

            for(int i = 0;i<targetKeysAndValues.Length;i++)
            {
                var data = targetKeysAndValues[i].Split(':');
                targetsData[targetName][data[0]] = data[1];
            }
                
        }

        var target = ReadLine().Substring(5);

        if(targetsData.ContainsKey(target))
        {
            WriteLine($"Info on {target}:");
            var sortedInfo = targetsData[target].OrderBy(k => k.Key);
            var infoIndex = 0;
            foreach(var pair in sortedInfo)
            {
                infoIndex += pair.Key.Length + pair.Value.Length;
                WriteLine($"---{pair.Key}: {pair.Value}");
            }

            WriteLine($"Info index: {infoIndex}");
            WriteLine(infoIndex >= targetInfoIndex ? "Proceed" : $"Need {targetInfoIndex - infoIndex} more info.");
        }
    }
}