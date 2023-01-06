using System;
using System.Collections.Generic;
using System.Linq;

namespace Recognizer
{
	internal static class MedianFilterTask
	{
		public static double[,] MedianFilter(double[,] original)
		{
			var width = original.GetLength(0);
			var height = original.GetLength(1);
			var medianFilter = new double[width, height];
			for (var i = 0; i < width; i++)
				for(var j = 0; j < height; j++)
					medianFilter[i, j] =  GetMedian(i, j, original);
			return medianFilter;
		}
		public static double GetMedian(int x, int y, double[,] original)
		{
			var currMedian = new List<double>();
			var width = original.GetLength(0);
			var height = original.GetLength(1);	
			var widthLowerLimit = Math.Max(0, x - 1);
			var heightLowerLimit = Math.Max(0, y - 1);
			var widthUpperLimit = Math.Min(width - 1, x + 1);
			var heightUpperLimit = Math.Min(height - 1, y + 1);

			for (var i = widthLowerLimit; i <= widthUpperLimit; i++)
				for (var j = heightLowerLimit; j <= heightUpperLimit; j++)
					currMedian.Add(original[i, j]);
			currMedian.Sort();
			if (currMedian.Count % 2 == 0)
				return (currMedian[currMedian.Count / 2] + currMedian[(currMedian.Count / 2) - 1]) / 2;
			return currMedian[currMedian.Count / 2];
		}
	}
}