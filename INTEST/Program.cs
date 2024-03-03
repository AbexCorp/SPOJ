using System;

namespace INTEST
{
    class Program
    {
        public static void Main()
        {
            string[] firstInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int testCases = int.Parse(firstInput[0]), mod = int.Parse(firstInput[1]);
            int counter = 0;
            for (int i = 0; i < testCases; i++)
            {
                counter = int.Parse(Console.ReadLine()) % mod == 0 ? counter + 1 : counter;
            }
            Console.WriteLine(counter);
        }
    }
}