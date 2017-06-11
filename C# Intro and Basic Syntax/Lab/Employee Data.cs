using static System.Console;

class Program
{
  static void Main()
  {
    var name = ReadLine();
    var age = int.Parse(ReadLine());
    var eID = int.Parse(ReadLine());
    var salary = double.Parse(ReadLine());

    WriteLine($@"Name: {name}
Age: {age}
Employee ID: {eID:D8}
Salary: {salary:F2}");
  }
}
