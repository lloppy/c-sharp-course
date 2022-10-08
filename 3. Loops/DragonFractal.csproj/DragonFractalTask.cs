// В этом пространстве имен содержатся средства для работы с изображениями. 
// Чтобы оно стало доступно, в проект был подключен Reference на сборку System.Drawing.dll

using System;
using System.Drawing;

namespace Fractals
{
	internal static class DragonFractalTask
	{
		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{
			var x = 1.0;
			var y = 0.0;
			var random = new Random(seed);

			for (int iteration = 0; iteration < iterationsCount; iteration++)
			{
				var nextNumber = random.Next(2);

				(double newX, double newY)[] possiblePosition =
					{ConvertRandom(x, y, Math.PI / 4, 0), ConvertRandom(x, y, 3 * Math.PI / 4, 1)};

				(x, y) = possiblePosition[nextNumber];
				pixels.SetPixel(x, y);
			}
		}
		
		private static (double newX, double newY) ConvertRandom(double x, double y, double angle, int step)
		{
			var newX = (x * Math.Cos(angle) - y * Math.Sin(angle)) / Math.Sqrt(2) + step;
			var newY = (x * Math.Sin(angle) + y * Math.Cos(angle)) / Math.Sqrt(2);

			return (newX, newY);
		}
	}
}

/*
			Начните с точки (1, 0)
			Создайте генератор рандомных чисел с сидом seed
			
			На каждой итерации:

			1. Выберите случайно одно из следующих преобразований и примените его к текущей точке:

				Преобразование 1. (поворот на 45° и сжатие в sqrt(2) раз):
				x' = (x · cos(45°) - y · sin(45°)) / sqrt(2)
				y' = (x · sin(45°) + y · cos(45°)) / sqrt(2)

				Преобразование 2. (поворот на 135°, сжатие в sqrt(2) раз, сдвиг по X на единицу):
				x' = (x · cos(135°) - y · sin(135°)) / sqrt(2) + 1
				y' = (x · sin(135°) + y · cos(135°)) / sqrt(2)
		
			2. Нарисуйте текущую точку методом pixels.SetPixel(x, y)*/