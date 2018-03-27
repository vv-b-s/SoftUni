using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Interfaces
{
    public interface ILayout
    {
        string CreateLine(string dateTimeInfo, string levelOfImportance, string message);
    }
}
