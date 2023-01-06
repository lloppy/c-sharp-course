namespace Recognizer
{
	public static class GrayscaleTask
	{
		public static double[,] ToGrayscale(Pixel[,] original)
		{
			var width = original.GetLength(0);
			var height = original.GetLength(1);
			var grayscale = new double[width, height];
			for (var x = 0; x < width; x++)
			{
				for (var y = 0; y < height; y++)
				{
					var coordPixels = original[x, y];
					grayscale[x, y] = (0.299 * coordPixels.R + 0.587 * coordPixels.G + 0.114 * coordPixels.B) / 255;
				}
			}
			return grayscale;		
		}
	}
}