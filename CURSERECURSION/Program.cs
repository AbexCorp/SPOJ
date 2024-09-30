using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        int numberOfTests = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Number of tests"));
        for (int i = 0; i < numberOfTests; i++)
        {
            string[] numbers = (Console.ReadLine() ?? throw new ArgumentException("Number of tests")).Split(' ', StringSplitOptions.RemoveEmptyEntries);
            sb.AppendLine($"{FindKthElement(long.Parse(numbers[0]), long.Parse(numbers[1]))}");
        }
        Console.WriteLine(sb.ToString());
    }

    static long FindKthElement(long maxN, long kIndex)
    {
        if(kIndex >= Math.Pow(2, maxN))
        {
            return 0;
        }
        if(kIndex % 2 == 1)
            return 1;

        long index = 2;
        long ans = 2;
        long increment = 2;
        while(index != kIndex)
        {
            if(kIndex > index)
            {
                index = index * 2;
                ans++;
                increment = increment * 2;
            }
            if(kIndex < index)
            {
                index = index / 2;
                ans -= 2;
                increment = increment / 4;
                if(index + increment <= kIndex)
                    index = index + increment;
            }
        }

        return ans;
    }
}