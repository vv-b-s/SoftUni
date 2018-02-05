using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

class Program
{
    public static void Main(string[] args)
    {
        Write("Enter the path of the file you want to copy: ");
        var fileToCopy = new FileInfo(ReadLine());

        Write("Enter the path of the folder you want to place the copy: ");
        var pasteLocation = ReadLine();
        
        //Get the name of the original file without extension
        var originalFileName = fileToCopy.Name.Substring(0, fileToCopy.Name.IndexOf(fileToCopy.Extension));

        //Create the path for the copy. The output would look like C:\Location\YYYY-Copy.ext where YYYY is the name of the original file
        var copiedFileInfo = new FileInfo(pasteLocation + @"\" + originalFileName + "-Copy" + fileToCopy.Extension);

        using (var originalFile = new FileStream(fileToCopy.FullName, FileMode.Open))
        {
            //Open a stream to write the copy
            using (var copyFile = new FileStream(copiedFileInfo.FullName, FileMode.Create))
                CopyFile(originalFile, copyFile);
        }

        WriteLine("Operation complete.");
    }

    /// <summary>
    /// Copy file from one location to another
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dest"></param>
    private static void CopyFile(FileStream src, FileStream dest)
    {
        //Allocate buffer 4096 bytes / 4Kb is the optimal size for Windows file management
        var buffer = new byte[4096];

        while(true)
        {
            //Read the data from the source file and get the count of the read bytes
            var readBytes = src.Read(buffer, 0, buffer.Length);

            //Use the information to know when the copying has ended
            if (readBytes == 0)
                break;

            //Write the read bytes to the destination file. Here we use the size of the read bytes because the buffer may be bigger.
            dest.Write(buffer, 0, readBytes);
        }
    }
}