using System;
using static System.Console;

public class Test
{
	public static void Main()
	{
		int[] creditN = {int.Parse(ReadLine()),int.Parse(ReadLine()),int.Parse(ReadLine()),int.Parse(ReadLine())};
			WriteLine($"{creditN[0]:D4} {creditN[1]:D4} {creditN[2]:D4} {creditN[3]:D4}");
	}
}
