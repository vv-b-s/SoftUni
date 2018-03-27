using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Writables
{
    class LogFile : IWritableFile
    {
        private const string DefaultFileName = @"\log";

        private FileInfo file;
        private StringBuilder sB;

        public LogFile() : this(Environment.CurrentDirectory) { }

        public LogFile(string fileLocation)
        {
            var fileName = GenerateFileName(fileLocation);

            this.file = new FileInfo(fileName);
            this.sB = new StringBuilder();
        }

        public long Size => this.sB.ToString().Sum(c => char.IsLetter(c)? (int) c : 0);

        public void Write(string line)
        {
            this.sB.Append(line);
            File.AppendAllText(this.file.FullName, line);
        }

        private string GenerateFileName(string fileLocation)
        {
            var logNumber = 0;
            var fileName = "";

            do
            {
                fileName = $"{fileLocation}{DefaultFileName}{logNumber}.txt";
                logNumber++;
            }
            while (File.Exists(fileName));

            return fileName;
        }
    }
}
