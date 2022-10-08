using System;

namespace AngryBirds
{
    public static class AngryBirdsTask
	{
		/// <param name="speed">Начальная скорость</param>
		/// <param name="distance">Расстояние до цели</param>
		/// <returns>Угол прицеливания в радианах от 0 до Pi/2</returns>

		public static double FindSightAngle(double speed, double distance)
		{
            return 0.5 * Math.Asin(distance * 9.8 / (speed * speed));
		}
	}
}