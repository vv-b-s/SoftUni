using System;
using static System.Console;

public class Test
{
	public static void Main()
	{
		int size = int.Parse(ReadLine());
		int innerFill = size-2;
		for(int i=0;i<(size-1)/2;i++)
		{
			WriteLine(new string(' ',i)+"x"+new string(' ',innerFill)+"x");
			innerFill-=2;
		}
		WriteLine(new string(' ',(size-1)/2)+"x");

		innerFill=1;
		for(int i=(size-1)/2-1;i>=0;i--)
		{
			WriteLine(new string(' ',i)+"x"+new string(' ',innerFill)+"x");
			innerFill+=2;
		}
	}
}
