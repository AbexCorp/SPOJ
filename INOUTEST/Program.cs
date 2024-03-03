using System;
using System.Text;

namespace INOUTEST
{
    class Program
    {
        public static void Main()
        {
            StringBuilder sb = new StringBuilder();
            int testCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
                sb.AppendLine((numbers[0] * numbers[1]).ToString());
            }
            Console.WriteLine(sb.ToString());
        }
    }
}