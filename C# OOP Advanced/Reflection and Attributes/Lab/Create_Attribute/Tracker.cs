using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);

        var methods = type.GetMethods(BindingFlags.Instance|BindingFlags.Public|BindingFlags.Static);
        
        foreach(var method in methods)
        {
            var attrs = method.GetCustomAttributes(false).Where(a => a is SoftUniAttribute).Cast<SoftUniAttribute>();

            if (attrs.Count()>0)
                Console.WriteLine(string.Join(Environment.NewLine, attrs.Select(a=>$"{method.Name} is written by {a.Name}")));
        }

    }
}