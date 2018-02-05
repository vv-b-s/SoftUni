using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

class SlicingFile
{
    public static void Main(string[] args)
    {
        Write("1 - Slice or 2 - Assemble: ");

        int.TryParse(ReadLine(), out int input);

        //Slice
        if (input == 1)
        {
            Write("Enter the path of the file you want to slice: ");
            var filePath = ReadLine();

            Write("Enter the directory you want to place the sliced bits: ");
            var destination = ReadLine();

            Write("Enter the number of parts you want to slice your file in: ");
            int.TryParse(ReadLine(), out int numberOfParts);

            Slice(filePath, destination, numberOfParts);
        }

        //Assemble
        else if (input == 2)
        {
            Write("Enter the location of the slices. They must contain the name Part-X.ext where X is the number of the part: ");
            var slicesFolder = new DirectoryInfo(ReadLine());

            Write("Enter the directory of the place you want to paste the file after assembled: ");
            var destination = ReadLine();

            //Make a pattern to validate files
            var pattern = new Regex(@"^(.+)Part-(?<partNumber>\d+)\..+$");

            //Get the files only with a valid name and order them by their part number
            var files = slicesFolder
                .GetFiles()
                .Select(file => file.FullName)
                .Where(file => pattern.IsMatch(file))
                .OrderBy(file => int.Parse(pattern.Match(file).Groups["partNumber"].Value))
                .ToList();

            Assemble(files, destination);
        }
        else
            WriteLine("Invalid operation.");
    }

    /// <summary>
    /// Slices the file into peaces and places everything into the shown folder
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="destination"></param>
    /// <param name="numberOfParts"></param>
    private static void Slice(string filePath, string destination, int numberOfParts)
    {
        //Create a folder inside the destination to hold the sliced bits
        var slicesFolder = new DirectoryInfo(destination + "\\" + "slices");
        slicesFolder.Create();

        var srcFileInfo = new FileInfo(filePath);

        //Slice the file
        using (var srcFile = new FileStream(filePath, FileMode.Open))
        {
            //Find out how many bytes should one part be.
            var sizeOfEachPart = (long)Math.Ceiling(srcFileInfo.Length / (double)numberOfParts);

            //Although 4kb is the optimal size for a buffer we want to slice the file to exactly as many as wanted pieces so the buffer is 1 piece long
            var buffer = new byte[sizeOfEachPart];

            //Slice the file
            var sliceTitle = "Part-";
            var partNumber = -1;
            var extension = srcFileInfo.Extension;
            var nameOfSlice = IncrementFileName(slicesFolder.ToString(), sliceTitle, ref partNumber, extension);

            while(true)
            {
                //Get the part of the file
                var readBytes = srcFile.Read(buffer, 0, buffer.Length);

                if (readBytes == 0)
                    break;

                //Create the slice
                using (var slice = new FileStream(nameOfSlice, FileMode.Create))
                    slice.Write(buffer, 0, readBytes);

                //Create the name for the next file
                nameOfSlice = IncrementFileName(slicesFolder.ToString(), sliceTitle, ref partNumber, extension);
            }

            WriteLine("Operation complete.");
        }
    }

    /// <summary>
    /// Assembles sliced files
    /// </summary>
    /// <param name="files"></param>
    /// <param name="destinationDirectory"></param>
    private static void Assemble(List<string> files, string destinationDirectory)
    {
        //Get the extension of the file
        var extention = new FileInfo(files[0]).Extension;

        //Create the name of the assembled file
        var assembledFile = destinationDirectory + "\\" + "assembled" + extention;

        //open the stream and write the slices
        using (var assembled = new FileStream(assembledFile, FileMode.Create))
        {
            //Read each file's data and copy it to assembled
            foreach(var file in files)
            {
                using (var sliceFile = new FileStream(file, FileMode.Open))
                    CopyFile(sliceFile, assembled);
            }
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

        while (true)
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

    private static string IncrementFileName(string directoryName, string fileName, ref int sliceNumber, string extension)
    {
        sliceNumber++;
        return directoryName + "\\" + fileName + sliceNumber + extension;
    }
}