using System;
using System.Collections.Generic;

namespace Recognizer
{
	public static class ThresholdFilterTask
	{
		public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
		{
			var width = original.GetLength(0);
			var height = original.GetLength(1);
			var thresholdFilterImage = new double[width, height];

			var t = FindT(original, whitePixelsFraction);
			
			for (var x = 0; x < width; x++)
				for (var y = 0; y < height; y++)
					if (original[x, y] >= t)
						thresholdFilterImage[x, y] = 1.0;
					else thresholdFilterImage[x, y] = 0.0; 
			return thresholdFilterImage;		
		}
		
		private static double FindT(double[,] original, double whitePixelsFraction)
		{
			var pixels = new List<double>();
			foreach (var pixel in original)
				pixels.Add(pixel);
			pixels.Sort();
			pixels.Reverse();
			
			var n = (int)(whitePixelsFraction * original.GetLength(0) * original.GetLength(1));
			if (n > 0)
				return pixels[n - 1];
			return 256;
		}
	}
}