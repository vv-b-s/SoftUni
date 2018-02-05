using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

class ZippingSlicedFiles
{
    public enum Option { Slice = 1, Assemble, SliceAndCompress, DecompressAndAssemble }
    public static void Main(string[] args)
    {
        WriteLine("1 - Slice\n2 - Assemble\n3 - Slice and compress\n4 - Decompress and assemble\nPlease use absolute paths!");
        Write("Your option: ");

        int.TryParse(ReadLine(), out int input);
        var option = (Option)input;

        #region Slice/Assemble
        //Slice
        if (option == Option.Slice)
        {
            Write("Enter the path of the file you want to slice: ");
            var filePath = ReadLine();

            Write("Enter the directory you want to place the sliced bits: ");
            var destination = ReadLine();

            Write("Enter the number of parts you want to slice your file in: ");
            int.TryParse(ReadLine(), out int numberOfParts);

            Slice(filePath, destination, numberOfParts);

            WriteLine("Operation complete.");
        }

        //Assemble
        else if (option == Option.Assemble)
        {
            Write("Enter the location of the slices. They must contain the name Part-X.ext where X is the number of the part: ");
            var slicesFolder = new DirectoryInfo(ReadLine());

            Write("Enter the directory of the place you want to paste the file after assembled: ");
            var destination = ReadLine();

            var files = GetSlicesFiles(slicesFolder);

            Assemble(files, destination);


            WriteLine("Operation complete.");
        }
        #endregion

        #region Compress/Decompress
        //Compression examples - https://msdn.microsoft.com/en-us/library/system.io.compression.gzipstream(v=vs.90).aspx

        //SliceAndCompress
        else if (option == Option.SliceAndCompress)
        {
            Write("Enter the path of the file you want to slice and compress: ");
            var srcFile = new FileInfo(ReadLine());

            Write("Enter the path of the directory you want to place the slices: ");
            var destDirectory = ReadLine();

            Write("In how many pieces do you want to slice the file: ");
            int.TryParse(ReadLine(), out int numberOfSlices);

            //Slice the file
            var slices = Slice(srcFile.FullName, destDirectory, numberOfSlices);

            //Compress and delete the slices
            foreach(var slice in slices)
            {
                Compress(slice.FullName, slice.Directory.ToString());
                slice.Delete();
            }

            WriteLine("Operation complete!");
        }

        //DecompressAndAssemble
        else if (option == Option.DecompressAndAssemble)
        {
            Write("Enter the directory of the slices: ");
            var slicesFolder = new DirectoryInfo(ReadLine());

            Write("Enter the directory you want to get the output file after decompression: ");
            var outputDirectory = ReadLine();

            //Get the compressed slices
            var files = GetSlicesFiles(slicesFolder);

            //Create a temporal directory to keep decompressed files in
            var tmpDecompressedSlices = new DirectoryInfo(slicesFolder + "\\tmp");
            tmpDecompressedSlices.Create();

            //Decompress the files
            foreach(var file in files)
                Decompress(new FileInfo(file), tmpDecompressedSlices.ToString());

            //Get the decompressed slices
            files = GetSlicesFiles(tmpDecompressedSlices);

            //Assemble the slices
            var assembleSlices = Assemble(files, outputDirectory);

            //Delete the temporal folder and its contents
            foreach (var file in tmpDecompressedSlices.GetFiles())
                file.Delete();
            tmpDecompressedSlices.Delete();
            

            WriteLine("Operation complete.");
        }
        #endregion

        else
            WriteLine("Invalid operation.");
    }

    /// <summary>
    /// Performs a compression on a file
    /// </summary>
    /// <param name="srcPath"></param>
    /// <param name="destDirectory"></param>
    /// <returns></returns>
    private static FileInfo Compress(string srcPath, string destDirectory)
    {
        var src = new FileInfo(srcPath);
        
        //Create temporal file before slicing
        var outputFile = new FileInfo(destDirectory + "\\" + $"{src.Name}.gz");

        using (var srcFile = src.OpenRead())
        {
            var buffer = new byte[4096];

            //Create the compressed file
            using (var tempCompressed = outputFile.OpenWrite())
            {
                //Open GZip compression stream
                using (var compress = new GZipStream(tempCompressed, CompressionMode.Compress))
                    //Perform compression
                    CopyFile(srcFile, compress);
            }
        }

        return outputFile;
    }

    /// <summary>
    /// Returns a compressed file into its original state
    /// </summary>
    /// <param name="compressedFile"></param>
    /// <param name="outputDirectory"></param>
    private static void Decompress(FileInfo compressedFile, string outputDirectory)
    {
        var srcExtension = GetFileExtension(compressedFile);

        //Get the original name of the file. If the zip is YYYY.xls.gz  the original fie name is YYYY
        var originalFileName = compressedFile.Name.Substring(0, compressedFile.Name.LastIndexOf(srcExtension));

        //If the extension is .xls.gz then the original extension is .xls
        var originalExtension = srcExtension.Substring(0, srcExtension.LastIndexOf("."));

        var decompressedFileName = new FileInfo(outputDirectory + "\\" + originalFileName + originalExtension);

        using (var compressedFileStream = compressedFile.OpenRead())
        {
            using (var decompressedFile = decompressedFileName.OpenWrite())
            {
                //Open compression stream
                using (var decompress = new GZipStream(compressedFileStream, CompressionMode.Decompress))
                    //Perform decompression
                    CopyFile(decompress, decompressedFile);
            }
        }
    }

    /// <summary>
    /// Slices the file into peaces and places everything into the shown folder
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="destination"></param>
    /// <param name="numberOfParts"></param>
    private static List<FileInfo> Slice(string filePath, string destination, int numberOfParts)
    {
        //Create a folder inside the destination to hold the sliced bits
        var slicesFolder = new DirectoryInfo(destination + "\\" + "slices");
        slicesFolder.Create();

        var srcFileInfo = new FileInfo(filePath);
        var outputFiles = new List<FileInfo>();

        //Slice the file
        using (var srcFile = srcFileInfo.OpenRead())
        {
            //Find out how many bytes should one part be.
            var sizeOfEachPart = (long)Math.Ceiling(srcFileInfo.Length / (double)numberOfParts);

            //Although 4kb is the optimal size for a buffer we want to slice the file to exactly as many as wanted pieces so the buffer is 1 piece long
            var buffer = new byte[sizeOfEachPart];

            //Slice the file
            var sliceTitle = "Part-";
            var partNumber = -1;
            var extension = GetFileExtension(srcFileInfo);
            var nameOfSlice = new FileInfo(IncrementFileName(slicesFolder.ToString(), sliceTitle, ref partNumber, extension));

            int readBytes;
            while ((readBytes = srcFile.Read(buffer, 0, buffer.Length)) != 0)
            {
                outputFiles.Add(nameOfSlice);

                //Create the slice
                using (var slice = new FileStream(nameOfSlice.FullName, FileMode.Create))
                    slice.Write(buffer, 0, readBytes);

                //Create the name for the next file
                nameOfSlice = new FileInfo(IncrementFileName(slicesFolder.ToString(), sliceTitle, ref partNumber, extension));
            }
        }

        return outputFiles;
    }

    /// <summary>
    /// Assembles sliced files
    /// </summary>
    /// <param name="files"></param>
    /// <param name="destinationDirectory"></param>
    /// <returns></returns>
    private static FileInfo Assemble(List<string> files, string destinationDirectory)
    {
        //Get the extension of the file
        var extention = GetFileExtension(new FileInfo(files[0]));

        //Create the name of the assembled file
        var assembledFile = destinationDirectory + "\\" + "assembled" + extention;

        //open the stream and write the slices
        using (var assembled = new FileStream(assembledFile, FileMode.Create))
        {
            //Read each file's data and copy it to assembled
            foreach (var file in files)
            {
                using (var sliceFile = new FileStream(file, FileMode.Open))
                    CopyFile(sliceFile, assembled);
            }
        }

        return new FileInfo(assembledFile);
    }

    /// <summary>
    /// Copy file from one location to another
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dest"></param>
    private static void CopyFile(Stream src, Stream dest)
    {
        //Allocate buffer 4096 bytes / 4Kb is the optimal size for Windows file management
        var buffer = new byte[4096];

        int readBytes;
        while ((readBytes = src.Read(buffer, 0, buffer.Length)) != 0)
            dest.Write(buffer, 0, readBytes);
    }

    /// <summary>
    /// If the file extension is .gz it means that it contains a subextension of the original file
    /// </summary>
    /// <param name="srcFileInfo"></param>
    /// <returns></returns>
    private static string GetFileExtension(FileInfo srcFileInfo)
    {
        if (srcFileInfo.Extension != ".gz")
            return srcFileInfo.Extension;

        var extension = Regex.Match(srcFileInfo.Name, @"\..+\.gz$").Value;
        return extension;
    }

    /// <summary>
    /// When creating parts it increments the number of the part
    /// </summary>
    /// <param name="directoryName"></param>
    /// <param name="fileName"></param>
    /// <param name="sliceNumber"></param>
    /// <param name="extension"></param>
    /// <returns></returns>
    private static string IncrementFileName(string directoryName, string fileName, ref int sliceNumber, string extension)
    {
        sliceNumber++;
        return directoryName + "\\" + fileName + sliceNumber + extension;
    }

    /// <summary>
    /// Gets the valid slices from a folder and sorts rthem
    /// </summary>
    /// <param name="slicesFolder"></param>
    /// <returns></returns>
    private static List<string> GetSlicesFiles(DirectoryInfo slicesFolder)
    {
        //Make a pattern to validate files
        var pattern = new Regex(@"^(.+)Part-(?<partNumber>\d+)\..+$");

        //Get the files only with a valid name and order them by their part number
        return slicesFolder
                .GetFiles()
                .Select(file => file.FullName)
                .Where(file => pattern.IsMatch(file))
                .OrderBy(file => int.Parse(pattern.Match(file).Groups["partNumber"].Value))
                .ToList();
    }
}