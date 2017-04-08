using System;
using static System.Console;

class Program
{
    static void Main()
    {
        double input = (double)ReadNum(), output = 0;
        string[] type = { ReadLine(), ReadLine() };

        double mm = 1000, cm = 100, mi = 0.000621371192, inch = 39.3700787, km = 0.001, ft = 3.2808399, yd = 1.0936133;

        if (type[0] == "mm")
        {
            if (type[1] == "cm")
                output = (input / mm) * cm;
            if (type[1] == "mi")
                output = (input / mm) * mi;
            if (type[1] == "in")
                output = (input / mm) * inch;
            if (type[1] == "km")
                output = (input / mm) * km;
            if (type[1] == "ft")
                output = (input / mm) * ft;
            if (type[1] == "yd")
                output = (input / mm) * yd;
            if (type[1] == "m")
                output = input / mm;
            if (type[1] == "mm")
                output = input;
        }

        if (type[0] == "cm")
        {
            if (type[1] == "mm")
                output = (input / cm) * mm;
            if (type[1] == "mi")
                output = (input / cm) * mi;
            if (type[1] == "in")
                output = (input / cm) * inch;
            if (type[1] == "km")
                output = (input / cm) * km;
            if (type[1] == "ft")
                output = (input / cm) * ft;
            if (type[1] == "yd")
                output = (input / cm) * yd;
            if (type[1] == "m")
                output = input / cm;
            if (type[1] == "cm")
                output = input;
        }

        if (type[0] == "mi")
        {
            if (type[1] == "mm")
                output = (input / mi) * mm;
            if (type[1] == "cm")
                output = (input / mi) * cm;
            if (type[1] == "in")
                output = (input / mi) * inch;
            if (type[1] == "km")
                output = (input / mi) * km;
            if (type[1] == "ft")
                output = (input / mi) * ft;
            if (type[1] == "yd")
                output = (input / mi) * yd;
            if (type[1] == "m")
                output = input / mi;
            if (type[1] == "mi")
                output = input;
        }

        if (type[0] == "in")
        {
            if (type[1] == "mm")
                output = (input / inch) * mm;
            if (type[1] == "cm")
                output = (input / inch) * cm;
            if (type[1] == "mi")
                output = (input / inch) * mi;
            if (type[1] == "km")
                output = (input / inch) * km;
            if (type[1] == "ft")
                output = (input / inch) * ft;
            if (type[1] == "yd")
                output = (input / inch) * yd;
            if (type[1] == "m")
                output = input / inch;
            if (type[1] == "in")
                output = input;
        }

        if (type[0] == "km")
        {
            if (type[1] == "mm")
                output = (input / km) * mm;
            if (type[1] == "mi")
                output = (input / km) * mi;
            if (type[1] == "in")
                output = (input / km) * inch;
            if (type[1] == "cm")
                output = (input / km) * cm;
            if (type[1] == "ft")
                output = (input / km) * ft;
            if (type[1] == "yd")
                output = (input / km) * yd;
            if (type[1] == "m")
                output = input / km;
            if (type[1] == "km")
                output = input;
        }

        if (type[0] == "ft")
        {
            if (type[1] == "mm")
                output = (input / ft) * mm;
            if (type[1] == "mi")
                output = (input / ft) * mi;
            if (type[1] == "in")
                output = (input / ft) * inch;
            if (type[1] == "km")
                output = (input / ft) * km;
            if (type[1] == "cm")
                output = (input / ft) * cm;
            if (type[1] == "yd")
                output = (input / ft) * yd;
            if (type[1] == "m")
                output = input / ft;
            if (type[1] == "ft")
                output = input;
        }

        if (type[0] == "yd")
        {
            if (type[1] == "mm")
                output = (input / yd) * mm;
            if (type[1] == "mi")
                output = (input / yd) * mi;
            if (type[1] == "in")
                output = (input / yd) * inch;
            if (type[1] == "km")
                output = (input / yd) * km;
            if (type[1] == "ft")
                output = (input / yd) * ft;
            if (type[1] == "cm")
                output = (input / yd) * cm;
            if (type[1] == "m")
                output = input / yd;
            if (type[1] == "yd")
                output = input;
        }

        if (type[0] == "m")
        {
            if (type[1] == "mm")
                output = input * mm;
            if (type[1] == "mi")
                output = input * mi;
            if (type[1] == "in")
                output = input * inch;
            if (type[1] == "km")
                output = input * km;
            if (type[1] == "ft")
                output = input * ft;
            if (type[1] == "yd")
                output = input * yd;
            if (type[1] == "cm")
                output = input * cm;
            if (type[1] == "m")
                output = input;
        }

        WriteLine(output + " " + type[0]);
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
