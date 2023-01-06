using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            var result = new double[width, height];
            var sy = TransposeMatrix(sx);
            var bias = sx.GetLength(0) / 2;

            for (int x = bias; x < width - bias; x++)
                for (int y = bias; y < height - bias; y++)
                {
                    var gy = MultiplyPixels(g, sy, x, y, bias);
                    var gx = MultiplyPixels(g, sx, x, y, bias);
                    result[x, y] = Math.Sqrt(gy * gy + gx * gx);
                }
            return result;
        }
        
        private static double[,] TransposeMatrix(double[,] matrix)
        {
            var length = matrix.GetLength(0);
            var transposedMatrix = new double[length, length];
            for (var x = 0; x < length; x++)
                for (var y = 0; y < length; y++)
                    transposedMatrix[x, y] = matrix[y, x];
            return transposedMatrix;
        }
        
        private static double MultiplyPixels(double[,] pixels, double[,] matrix, int x, int y, int bias)
        {
            double result = 0;
            int sideLength = matrix.GetLength(0);
            for (var i = 0; i < sideLength; i++)
                for (var j = 0; j < sideLength; j++)
                    result += matrix[i, j] * pixels[x - bias + i, y - bias + j];
            return result;
        }
    }
}