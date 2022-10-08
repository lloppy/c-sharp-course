using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			return Math.Min(r1.Bottom, r2.Bottom) >= Math.Max(r1.Top, r2.Top) 
			       && Math.Min(r1.Right, r2.Right) >= Math.Max(r1.Left, r2.Left);
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			if (!AreIntersected(r1, r2)) return 0;

			return FindDifferenceMinMax(r1.Right, r2.Right, r1.Left, r2.Left)
			       * FindDifferenceMinMax(r1.Bottom, r2.Bottom, r1.Top, r2.Top);
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			if (DefineNesting(r1.Left - r2.Left ,r1.Right - r2.Right, r1.Bottom - r2.Bottom, r1.Top - r2.Top)) return 0;

			if (DefineNesting(r2.Left - r1.Left, r2.Right - r1.Right, r2.Bottom - r1.Bottom, r2.Top - r1.Top)) return 1;
			
			return -1;
		}

		private static bool DefineNesting(int leftSide, int rightSide, int bottomSide, int topSide)
		{
			return leftSide >= 0 && rightSide <= 0 && bottomSide <= 0 && topSide >= 0;
		}

		private static int FindDifferenceMinMax(int firstMin, int secMin, int firstMax, int secMax)
		{
			return Math.Min(firstMin, secMin) - Math.Max(firstMax, secMax);
		}
	}
}