using System;

namespace Billiards
{
    public static class BilliardsTask
	{ 
		/// <summary>Метод для расчета угла отскока шарика от стены</summary>
        /// <param name="directionRadians">Угол направления движения шара</param>
        /// <param name="wallInclinationRadians">Угол</param>
		/// <returns>Возвращается угол отскока шарика от стены: разность удвоенного наклона 				стены и угла направления
		/// </returns>

        public static double BounceWall(double directionRadians, double wallInclinationRadians)
		{
			return 2 * wallInclinationRadians - directionRadians;
        }
    }
}