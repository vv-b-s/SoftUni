using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

class DirectoryTraversal
{
    public static void Main(string[] args)
    {
        Write("Enter the path of the directory you want to traverse: ");
        var directory = new DirectoryInfo(ReadLine());

        //get the files of that directory
        var files = directory.GetFiles().ToList();

        //fill the files into the dictionary
        var extensionFiles = new Dictionary<string, List<FileInfo>>();
        foreach(var file in files)
        {
            var extension = file.Extension;

            if (!extensionFiles.ContainsKey(extension))
                extensionFiles[extension] = new List<FileInfo>();

            extensionFiles[extension].Add(file);
        }

        //sort out the dictionary
        extensionFiles = extensionFiles.Select(extensionFilePair =>
        {
            //Sort the list by file size
            extensionFilePair = new KeyValuePair<string, List<FileInfo>>(extensionFilePair.Key, extensionFilePair.Value.OrderBy(file => file.Length).ToList());
            return extensionFilePair;
        })
        //Sort the places on the list by count
        .OrderByDescending(extensionFilePair=>extensionFilePair.Value.Count) 
        .ToDictionary(k=>k.Key, v=>v.Value);

        //Save the output
        var sB = new StringBuilder();
        foreach (var fileEntry in extensionFiles)
        {
            sB.AppendLine(fileEntry.Key);
            foreach (var file in fileEntry.Value)
                sB.AppendLine($"--{file.Name} - {file.Length / 1024.0:F3}kb");
            sB.AppendLine();
        }

        //Write the report file
        var reportPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "\\report.txt";

        using (var report = new StreamWriter(reportPath))
            report.Write(sB.ToString());

        WriteLine("The report is written on the desktop.");
    }
}