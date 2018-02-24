using System;
using System.Collections.Generic;
using System.Text;

namespace Mordor_Cruel_Plan.Moods
{
    public abstract class Mood
    {
        public override string ToString() => GetType().Name;
    }
}
