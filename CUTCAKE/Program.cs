using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int numberOfTests = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Number of tests"));
        long[] people = ReadNumberOfPeople(numberOfTests);
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < people.Length; i++)
        {
            sb.AppendLine($"{CalculateNumberOfCuts(people[i])}");
        }
        Console.WriteLine();
        Console.WriteLine(sb.ToString());
    }
    static long[] ReadNumberOfPeople(int numberOfTests)
    {
        long[] people = new long[numberOfTests];
        for(int i = 0; i < numberOfTests; i++)
        {
            people[i] = long.Parse(Console.ReadLine() ?? throw new ArgumentException("Number of people"));
        }
        return people;
    }
    static long CalculateNumberOfCuts(long people)
    {
        if (people < 2)
            return 0;
        if (people == 2)
            return 1;

        long current = 2;
        while (true)
        {
            if ((((current * current) + current + 2) / 2) >= people)
                return current;;
            current++;
        }
    }
}