using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        string userInput;
        var PhoneBook = new Dictionary<string, string>();

        while((userInput=ReadLine())!="END")
        {
            char command = userInput.Split()[0][0];

            switch(command)
            {
                case 'A':
                    string name = userInput.Split()[1];
                    string number = userInput.Split()[2];
                    PhoneBook[name] = number;
                    break;
                case 'S':
                    name = userInput.Split()[1];
                    WriteLine(PhoneBook.Keys.Contains(name) ?
                        $"{name} -> {PhoneBook[name]}" :
                        $"Contact {name} does not exist.");
                    break;
            }
        }
    }
}