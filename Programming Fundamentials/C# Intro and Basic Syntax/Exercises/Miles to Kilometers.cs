using System;
using static System.Console;

public class Test
{
	public static void Main()
	{
	   double miles = double.Parse(ReadLine());
      WriteLine($"{miles*1.60934:F2}");
	}
}
