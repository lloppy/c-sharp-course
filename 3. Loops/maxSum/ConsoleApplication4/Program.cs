using System;

namespace ConsoleApplication4
{
    internal class Program
    {
        public static void Main()
        {
            
            //var array = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var array = new int[] {20, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            //var array = new int[] {1, 2, 3, 4, 55, 6, 7, 8, 9, 10};
            
            var m = int.Parse(Console.ReadLine()); //длина подмассива

            var maxSum = int.MinValue;
            var maxSumIndex = -1;
            
            for (var i = 0; i < array.Length - m + 1; i++)
            {
                var currSum = 0;
                for (var j = i; j < m + i; j++)
                    currSum += array[j];


                if (currSum > maxSum)
                {
                    maxSum = currSum;
                    maxSumIndex = i;
                }
            }

            var ans = "";
            for (var k = maxSumIndex; k < m + maxSumIndex; k++)
            {
                ans += array[k].ToString() + " ";
            }
            Console.WriteLine(ans);
        }
    }
    
}
