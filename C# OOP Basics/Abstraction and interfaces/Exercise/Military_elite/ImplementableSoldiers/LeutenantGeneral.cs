using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Military_elite.ImplementableSoldiers
{
    public class LeutenantGeneral:Private
    {
        private List<Private> privates;

        public LeutenantGeneral(string id, string firstName, string lastName,double salary, List<Private> privates):base(id, firstName,lastName,salary)
        {
            this.privates = privates ?? new List<Private>();            
        }

        public override string ToString()
        {
            var sB = new StringBuilder(base.ToString()+"\nPrivates:");

            if(privates.Count>0)
                sB.AppendLine();

            //Indent the lines two spaces further
            for(int i = 0;i<privates.Count;i++)
            {
                var lines = privates[i].ToString().Split('\n');
                sB.Append(string.Join(Environment.NewLine, lines.Select(l => $"  {l}")));

                if (i < privates.Count - 1)
                    sB.AppendLine();
            }

            return sB.ToString();
        }
    }
}
