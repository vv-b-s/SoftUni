using System;
using System.Collections.Generic;
using System.Text;

namespace DateTime_Now_AddDays.Tests
{
    public class FakeDateTime : IComparable
    {
        public FakeDateTime(int day, int month, int year)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }

        public FakeDateTime(DateTime date) : this(date.Day, date.Month, date.Year) { }

        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        /// <summary>
        /// Checks if two date are equal
        /// </summary>
        /// <param name="date">Either FakeDateTime or DateTime</param>
        /// <returns>Returns either 1 for false and 0 for true</returns>
        public int CompareTo(object date)
        {
            if (date is FakeDateTime fakeDate)
                return fakeDate.Day == this.Day && fakeDate.Month == this.Month && fakeDate.Year == this.Year ? 0 : 1;

            else if (date is DateTime dateTime)
                return dateTime.Day == this.Day && dateTime.Month == this.Month && dateTime.Year == this.Year ? 0 : 1;

            else throw new ArgumentException("Invalid date type!");
        }
    }
}
