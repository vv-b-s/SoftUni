using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Date_modifier
{
    class DateModifier
    {
        public static long GetDateDifferences(string date1, string date2)
        {
            var date1Data = GetDateData(date1);
            var date2Data = GetDateData(date2);

            var dateOne = new DateTime(date1Data[0], date1Data[1], date1Data[2]);
            var dateTwo = new DateTime(date2Data[0], date2Data[1], date2Data[2]);

            var diff = (dateOne - dateTwo).TotalDays;

            return (long)Math.Abs(diff);
        }

        private static int[] GetDateData(string date)
        {
            var output = new int[3];
            var dateData = date.Split().Where(i => i != "").ToArray();

            for (int i = 0; i < 3; i++)
                int.TryParse(dateData[i], out output[i]);

            return output;            
        }
    }
}
