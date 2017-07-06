﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class File
{
    public string FileName { set; get; }
    public string Location { set; get; }
    public string Extension { set; get; }
    public long Size { set; get; }

    public string FullFileName
    {
        get { return $"{FileName}.{Extension}"; }
        set
        {
            FileName = value.Substring(0, value.LastIndexOf('.'));
            Extension = value.Substring(value.LastIndexOf('.') + 1);
        }
    }

    public File(string fileName, string location, string size)
    {
        FileName = fileName.Substring(0,fileName.LastIndexOf('.'));
        Location = location;
        Extension = fileName.Substring(fileName.LastIndexOf('.') + 1);
        Size = long.Parse(size);
    }
}

class Program
{
    static void Main()
    {
        var pattern = new Regex(@"(?<root>.*\\)(?<fileName>.+);(?<fileSize>\d+)");

        var directories = new List<string>();
        for(int i=int.Parse(ReadLine());i>0;i--) 
            directories.Add(ReadLine());

        var Files = new Dictionary<string,List<File>>();
        foreach(var file in directories)
        {
            if(pattern.IsMatch(file))
            {
                var match = pattern.Match(file);
                var root = match.Groups["root"].Value;
                var fileName = match.Groups["fileName"].Value.Trim();
                var fileSize = match.Groups["fileSize"].Value;

                if (Regex.IsMatch(fileName, @"[^\.\\]\.[^\.\\\s]+$")&&!root.Contains(@"\\"))
                {
                    if (Files.ContainsKey(root))
                    {
                        if (Files[root].Any(f => string.Compare(f.FullFileName, fileName, true) == 0))
                        {
                            var fileToUpdate = Files[root].First(f => string.Compare(f.FullFileName, fileName, true) == 0);
                            fileToUpdate.Size = long.Parse(fileSize);
                            fileToUpdate.FullFileName = fileName;
                        }
                        else
                            Files[root].Add(new File(fileName, root, fileSize));
                    }
                    else
                        Files[root] = new List<File> { new File(fileName, root, fileSize) };
                }
            }
        }

        var querry = ReadLine();
        var querryLocation = Regex.Split(querry,@"\s")[2];
        var querryExtension = Regex.Split(querry, @"\s")[0];

        var filesToList = Files.Values.SelectMany(f => f).ToList();
        var querryList = filesToList.Where(f => f.Location.Contains(querryLocation) && string.Compare(f.Extension, querryExtension, true) == 0).ToList();

        if (querryList.Count == 0)
        {
            WriteLine("No");
            return;
        }

        querryList = querryList.OrderByDescending(f => f.Size).ThenBy(f => f.FullFileName).ToList();
        foreach (var file in querryList)
            WriteLine($"{file.FullFileName} - {file.Size} KB");
    }

    static string AddVar(string value)
    {
        var sB = new StringBuilder();
        sB.Append('{');
        sB.Append(value);
        sB.Append('}');
        return sB.ToString();
    }

}