using System;
using System.Text;
using System.Reflection; // <------------- Ще е забавно!
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace HelloSoftuni
{
    class HelloSoftUni
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
using System;
using System.Text;
namespace HelloSoftuni {
   public class AsciiTableClass {
       public static string[] AsciiTable = {");
            for (int i = 0; i < 128; i++)
            {
                if (i < 32 || i > 127)
                {
                    sb.Append("\"\"");
                }
                else
                {
                    char c = (char)i;
                    if (c == '"')
                    {
                        sb.Append("@\"\"\"\"");
                    }
                    else
                    {
                        sb.Append("@\"");
                        sb.Append(c);
                        sb.Append("\"");
                    }
                }
                sb.Append(@", ");
            }
            sb.Append(@"};
       public static string HelloSoftuni(string[] tbl) {
           StringBuilder sb = new StringBuilder();
");
            foreach (char c in "Hello C#!")
            {
                sb.Append(@"            sb.Append(tbl[" + (int)c + "]);\r\n");
            }
            sb.Append(@"            return sb.ToString();
       }
   }
}");
            CSharpCodeProvider shittycomp = new CSharpCodeProvider();
            CompilerParameters softparams = new CompilerParameters();
            softparams.GenerateInMemory = true;
            softparams.GenerateExecutable = false;
            CompilerResults res = shittycomp.CompileAssemblyFromSource(softparams, sb.ToString());
            if (res.Errors.HasErrors)
            {
                Console.WriteLine("Zaminavai, pich");
                return;
            }
            Assembly assembly = res.CompiledAssembly;
            Type finalres = assembly.GetType("HelloSoftuni.AsciiTableClass");
            FieldInfo softunitable = finalres.GetField("AsciiTable", BindingFlags.Public | BindingFlags.Static);
            MethodInfo finalSoftUniMethod = finalres.GetMethod("HelloSoftuni", BindingFlags.Public | BindingFlags.Static);
            Console.WriteLine(finalSoftUniMethod.Invoke(null, new object[] { softunitable.GetValue(null) }));

        }
    }
}