using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace RefactorMe
{
    class Painter
    {
        static float x, y;
        static Graphics graphics;

        public static void Initialize(Graphics newGraphics)
        {
            graphics = newGraphics;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            x = x0;
            y = y0;
        }

        public static void DrawTrajectory(Pen pen, double length, double angle)
        {
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graphics.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void CountTrajectory(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle));
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double cornerTurn, Graphics graphics)
        {
            Painter.Initialize(graphics);

            var size = Math.Min(width, height);
            var resized375 = size * 0.375f;
            var resized04 = size * 0.04f;

            var lengthDiagonal = Math.Sqrt(2) * (resized375 + resized04) / 2;
            var x0 = (float)(lengthDiagonal * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(lengthDiagonal * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Painter.SetPosition(x0, y0);

            double[] angles = { 0.0, -Math.PI / 2, Math.PI, Math.PI / 2 };
            BuildFigure(resized375, resized04, angles);
        }

        private static void BuildFigure(double resized375, double resized04, double[] angles)
        {
            foreach (int index in Enumerable.Range(0, angles.Length))
            {
                DepictFigure(resized375, resized04, angles[index]);
            }
        }

        private static void DepictFigure(double resized375, double resized04, double angle)
        {
            Painter.DrawTrajectory(Pens.Yellow, resized375, angle);
            Painter.DrawTrajectory(Pens.Yellow, resized04 * Math.Sqrt(2), angle + Math.PI / 4);
            Painter.DrawTrajectory(Pens.Yellow, resized375, angle + Math.PI);
            Painter.DrawTrajectory(Pens.Yellow, resized375 - resized04, angle + Math.PI / 2);

            Painter.CountTrajectory(resized04, angle - Math.PI);
            Painter.CountTrajectory(resized04 * Math.Sqrt(2), angle + 3 * Math.PI / 4);
        }
    }
}