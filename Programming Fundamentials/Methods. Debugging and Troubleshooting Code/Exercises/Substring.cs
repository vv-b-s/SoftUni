using System;

public class Substring_broken
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int jump = int.Parse(Console.ReadLine());

        const char Search = 'p';
        bool hasMatch = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == Search)
            {
                hasMatch = true;

                int endLength = jump+1;

                if (endLength+i >= text.Length)
                {
                    endLength = text.Length-i;
                }

                string matchedString = text.Substring(i, endLength);
                Console.WriteLine(matchedString);
                i += endLength-1;
            }
        }

        if (!hasMatch)
        {
            Console.WriteLine("no");
        }
    }
}
