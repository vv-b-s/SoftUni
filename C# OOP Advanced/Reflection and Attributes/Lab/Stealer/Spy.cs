using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] neededFields)
    {
        var type = Type.GetType(className);
        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
            .Where(f => neededFields.Any(nf => nf == f.Name));

        var output = $"Class under investigation: {className}{Environment.NewLine}";
        var instance = type.GetConstructor(new Type[] { }).Invoke(new object[] { });
        return output + string.Join(Environment.NewLine, fields.Select(f => $"{f.Name} = {f.GetValue(instance)}"));
    }

    public string AnalyzeAcessModifiers(string investigatedClass)
    {
        var classType = Type.GetType(investigatedClass);

        var stringBuilder = new StringBuilder();
        var classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        var classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        var classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var field in classFields)
        {
            if (field.IsPublic)
                stringBuilder.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            if (method.IsPrivate)
                stringBuilder.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            if (method.IsPublic)
                stringBuilder.AppendLine($"{method.Name} have to be private!");
        }

        return stringBuilder.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        var classType = Type.GetType(className);

        var privateMethods = classType.GetMethods(BindingFlags.NonPublic|BindingFlags.Instance);

        var sB = new StringBuilder();
        sB.AppendLine($"All Private Methods of Class: {className}");
        sB.AppendLine($"Base Class: {classType.BaseType.Name}");

        sB.Append(string.Join(Environment.NewLine, privateMethods.Select(m => m.Name)));

        return sB.ToString();
    }

    public string CollectGettersAndSetters(string className)
    {
        var type = Type.GetType(className);
        var bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;

        var accessors = GetMethodsByStartWord(type, "get", bindingFlags)
            .Concat(GetMethodsByStartWord(type, "set", bindingFlags)).ToArray();

        var output = accessors.Select(m => m.Name.StartsWith("get") ?
        $"{m.Name} will return {m.ReturnType.FullName}" :
        $"{m.Name} will set field of {m.GetParameters()[0].ParameterType.FullName}");

        return string.Join(Environment.NewLine, output);
    }

    private MethodInfo[] GetMethodsByStartWord(Type classType, string startWord, BindingFlags bindingFlags) =>
        classType.GetMethods(bindingFlags)
        .Where(m => m.Name.StartsWith(startWord))
        .ToArray();
}