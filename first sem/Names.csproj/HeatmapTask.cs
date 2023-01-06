using System;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var heatMap = new double[30, 12];

            foreach (var nameData in names)
            {
                if (nameData.BirthDate.Day != 1)
                    heatMap[nameData.BirthDate.Day-2, nameData.BirthDate.Month-1] += 1;
            }
            return new HeatmapData("Тепловая карта",
                heatMap, GenerateArray( 2,  30), GenerateArray( 1, 12));
        }

        private static string[] GenerateArray(int startValue, int maxValue)
        {
            var array = new string[maxValue];

            for (var i = 0; i < maxValue; i++)
            {
                array[i] = (i + startValue).ToString();
            }

            return array;
        }
    }
}