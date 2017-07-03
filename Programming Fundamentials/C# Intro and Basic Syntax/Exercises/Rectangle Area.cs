using System;
using static System.Console;

public class Test
{
	public static void Main()
	{
      double sideA = double.Parse(ReadLine());
      double sideB = double.Parse(ReadLine());
      WriteLine((sideA*sideB).ToString("F2"));
    }
}
