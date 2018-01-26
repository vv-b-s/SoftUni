using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

class SimpleTextEditor
{
    private static StringBuilder text;
    private static Stack<string> changeTracker;
    static void Main(string[] args)
    {
        int numberOfModifications = int.Parse(ReadLine());
        text = new StringBuilder();
        changeTracker = new Stack<string>();

        while (numberOfModifications-- > 0)
        {
            string[] modData = ReadLine().Split(' ');
            var modificationType = int.Parse(modData[0]);

            switch (modificationType)
            {
                case 1:
                    AppendText(modData[1]);
                    break;
                case 2:
                    RemoveChar(int.Parse(modData[1]));
                    break;
                case 3:
                    WriteLine(GetElement(int.Parse(modData[1])));
                    break;
                case 4:
                    UndoLastChange();
                    break;
            }
        }
    }

    /// <summary>
    /// Undoes the last change
    /// </summary>
    private static void UndoLastChange()
    {
        text.Clear();
        text.Append(changeTracker.Pop());
    }

    /// <summary>
    /// Gets an element from a certain positon
    /// </summary>
    /// <param name="position"></param>
    private static char GetElement(int position) => text[position-1];

    /// <summary>
    /// Removes as many characters from the text as needed
    /// </summary>
    /// <param name="charactersToRemove"></param>
    private static void RemoveChar(int charactersToRemove)
    {
        SavePreviousState();
        text.Remove(text.Length - charactersToRemove, charactersToRemove);
    }

    /// <summary>
    /// Pushes text to the stack
    /// </summary>
    /// <param name="text"></param>
    private static void AppendText(string text)
    {
        SavePreviousState();
        SimpleTextEditor.text.Append(text);
    }

    private static void SavePreviousState() => changeTracker.Push(text.ToString());
}