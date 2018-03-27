using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Writables
{
    public class Console : IWritableObject
    {
        public void Write(string line)
        {
            System.Console.Write(line);
        }
    }
}
