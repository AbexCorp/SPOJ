using System;
using System.Text;

class Program
{
    static int arrLength;
    static int[] array;
    static int subArrLength;

    static int backIndex = -1;
    static int frontIndex;
    static int maxNumber = -1;
    static int maxNumberIndex;

    static void Main(string[] args)
    {
        arrLength = int.Parse(Console.ReadLine());
        array = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
        subArrLength = int.Parse(Console.ReadLine());
        if (HandleEdgeCases())
            return;

        StringBuilder sb = new StringBuilder();
        frontIndex = subArrLength - 2;
        FindBiggestNumberInSubArray(backIndex + 1, frontIndex + 1);

        for (int i = frontIndex + 1; i < arrLength; i++)
        {
            frontIndex++;
            backIndex++;
            if (array[frontIndex] >= maxNumber)
            {
                maxNumber = array[frontIndex];
                maxNumberIndex = frontIndex;
                sb.Append($"{maxNumber} ");
                continue;
            }
            else if (maxNumberIndex < backIndex)
            {
                FindBiggestNumberInSubArray(backIndex, frontIndex);
                sb.Append($"{maxNumber} ");
                continue;
            }
            else
            {
                sb.Append($"{maxNumber} ");
                continue;
            }
        }
        Console.WriteLine(sb.ToString());
    }
    static void FindBiggestNumberInSubArray(int backIndex, int frontIndex)
    {
        maxNumber = -1;
        for (int i = backIndex; i <= frontIndex; i++)
        {
            if (array[i] >= maxNumber)
            {
                maxNumber = array[i];
                maxNumberIndex = i;
            }
        }
    }
    static bool HandleEdgeCases()
    {
        if (subArrLength == 1)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arrLength; i++)
            {
                sb.Append($"{array[i]} ");
            }
            Console.WriteLine(sb.ToString().Trim());
            return true;
        }
        else if (subArrLength == arrLength)
        {
            for (int i = 0; i < arrLength; i++)
            {
                if (array[i] >= maxNumber)
                    maxNumber = array[i];
            }
            Console.WriteLine(maxNumber);
            return true;
        }
        return false;
    }
}