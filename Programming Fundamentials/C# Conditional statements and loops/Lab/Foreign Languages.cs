using static System.Console;

class Program
{
    static void Main()
    {
        var country = ReadLine();
        string language;
        if (country == "England" || country == "USA")
            language = "English";
        else if (country == "Spain" || country == "Argentina" || country == "Mexico")
            language = "Spanish";
        else
            language = "unknown";
        WriteLine(language);
    }
}
