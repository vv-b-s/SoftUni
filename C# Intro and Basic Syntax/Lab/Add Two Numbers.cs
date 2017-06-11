using static System.Console;

class Program
{
  static void Main()
  {
    int n_1,n_2;
    int.TryParse(ReadLine(),out n_1);
    int.TryParse(ReadLine(),out n_2);
    WriteLine($"{n_1} + {n_2} = {n_1+n_2}");
  }
}
