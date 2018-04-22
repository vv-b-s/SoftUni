﻿namespace FestivalManager.Entities.Sets
{
	using System;

	public class Short : Set
	{
        private const int MaxTimeSpanMinutes = 15;

		public Short(string name) 
			: base(name, new TimeSpan(0, MaxTimeSpanMinutes, 0))
		{
		}
	}
}