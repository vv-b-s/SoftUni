﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalManager.Entities.Sets
{
    public class Long : Set
    {
        private const int MaxTimeSpanMinutes = 60;

        public Long(string name) : base(name, new TimeSpan(0,60,0))
        {
        }
    }
}
