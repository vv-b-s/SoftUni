using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using static System.Console;

class Program
{
 static void Main()
 {
  var charList = ReadLine().Split().Where(s => s.Length == 2).ToList();
  for (int i = 0; i < charList.Count; i++)
  {
   var temp = charList[i].ToCharArray();
   Array.Reverse(temp);
   charList[i] = new string(temp);
  }
  charList.Reverse();

  var outputList = charList.Select(c => Convert.ToInt32(c, 16)).Select(n => Convert.ToChar(n)).ToList();
  
  WriteLine(string.Join("",outputList));
 }
}