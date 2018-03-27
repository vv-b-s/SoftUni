using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Appenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout, IWritableObject file) : base(layout, file)
        {
            if (!(file is IWritableFile))
                throw new ArgumentException("The given WritableObject MUST Implement IWritableFile!");
        }

        public override string ToString()
        {
            var fileSize = ((IWritableFile)this.WritableObject).Size;
            var output = base.ToString() + $", File size: {fileSize}";

            return output;
        }
    }
}
