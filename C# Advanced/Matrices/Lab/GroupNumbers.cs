using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class GroupNumbers
{
    public static void Main(string[] args)
    {
        var numbers = ReadArray();

        // Use queues for more flexible solution
        var matrixQueues = new Queue<double>[3];

        //Initialize queues
        for (int i = 0; i < matrixQueues.Length; i++)
            matrixQueues[i] = new Queue<double>();

        foreach (var number in numbers)
            matrixQueues[(int)Math.Abs(number % 3)].Enqueue(number);

        foreach (var queue in matrixQueues)
            WriteLine(string.Join(" ", queue));
    }

    private static double[] ReadArray() => ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
}

