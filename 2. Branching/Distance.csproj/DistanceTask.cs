using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            //находим длины векторов (расстояние между началом и концом вектора)
            var sideAB = FindLengthVector(ax - bx, ay - by);
            var sideBC = FindLengthVector(bx - x, by - y);
            var sideAC = FindLengthVector(ax - x, ay - y);
            if (ax == bx && bx == x && ay == by && by == y) return 0; //точка
                    
            if (ax == bx && ay == by) return FindLengthVector(ax - x, ay - y);
            
            if (IsAngleObtuse(sideAC, sideBC, sideAB) || IsAngleObtuse(sideBC, sideAB, sideAC)) //тупоугольный
                return Math.Min(sideAC, sideBC);

            var semiP = (sideAB + sideBC + sideAC) / 2.0;
            var square = Math.Sqrt(Math.Abs(semiP * (semiP - sideAB) * (semiP - sideBC) * (semiP - sideAC)));
            var height = (2.0 * square) / sideAB;

            return height;
        }
        
        private static double FindLengthVector(double firstDifference, double secDifference)
        {
            return Math.Sqrt((firstDifference) * (firstDifference) + (secDifference) * (secDifference));
        }

        private static bool IsAngleObtuse(double firstBigSide, double secSide, double thirdSide)
        {
            return firstBigSide * firstBigSide > secSide * secSide + thirdSide * thirdSide;
        }
    }
}













/*
Если угол между векторами 
(вектором от ближайшей точки отрезка до самой точки и вектором 
вектором от дальней точки отрезка до самой точки) 
тупой
(то есть скалярное произведение векторов < 0, 
то просто находим расстояние от точки до ближайшей точки отрезка
(ax; ay) или(bx; by),
а иначе решаем за формулой расстояние от точки до прямой
(опускаем перпендикуляр). 

(ab * ab > bc * bc + ac * ac || bc * bc > ab * ab + ac * ac)
//пересекает ли отрезок, высота, опущенная из точки на отрезок(скалярные произведения векторов)
            var scalarA = (x - ax) * (bx - ax) + (y - ay) * (by - ay);
            var scalarB = (x - bx) * (bx - ax) + (y - by) * (by - ay);
            
            
if (ac * ac >= ab * ab + bc * bc) //для острого угла
                return ab;
            if (ab * ab >= ac * ac + bc * bc)
                return ac;
            
            var p = (ab + bc + ac) / 2.0;
            var s = (Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac)));
            var h = (2.0 * s) / ab;

            return h;
            
            
            
            
if (ab * ab > bc * bc + ac * ac || bc * bc > ab * ab + ac * ac) //угол тупой
            {
                return Math.Min(ac, bc);
            }
            else
            {
                var p = (ab + bc + ac) / 2.0;
                var s = (Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac)));
                var h = 2.0 * s / ab;

                return h;
            }
            
            
            
            var cos = (bc * bc + ac * ac - ab * ab) / (2.0 * bc * ac);
            if (1 > cos && cos > 0) //ostriy    
            {
                return Math.Min(ac, bc);
            }

            if (0 > cos && cos > -1) //tupoi
            { 
                var p = (ab + bc + ac) / 2.0; 
                var s = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac)); 
                var h = 2.0 * s / ab;
                
                return h;

            }
            
            if (cos == 0) //pryamougoln
            {
                return Math.Min(ac, bc);
            }

            if (cos == -1)
            {
                return Math.Min(ac, bc);
            }

            return 0;
            
            
            
            
            */
