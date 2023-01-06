using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var yLabels = new double[31];

            for (var i = 0; i < names.Length; i++)
            {
                var day = names[i].BirthDate.Day;
                if (day != 1 && names[i].Name == name)
                    yLabels[day - 1]++;
            }

            return new HistogramData(
                string.Format($"Рождаемость людей с именем '{name}'"),
                GenerateDays(31),
                yLabels);
        }
        
        private static string[] GenerateDays( int days)
        {
            var daysMonth = new string[days];
            for (var i = 0; i < days; i++)
                daysMonth[i] = (i + 1).ToString();
            return daysMonth;
        }
    }
}