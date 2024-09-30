using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int numberOfTests = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Number of tests"));
        int[] cuts = ReadNumberOfCuts(numberOfTests);
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < cuts.Length; i++)
        {
            sb.AppendLine($"{CalculateNumberOfSlices(cuts[i])}");
        }
        Console.WriteLine(sb.ToString());
    }
    static int[] ReadNumberOfCuts(int numberOfTests)
    {
        int[] cuts = new int[numberOfTests];
        for(int i = 0; i < numberOfTests; i++)
        {
            cuts[i] = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Number of cuts"));
        }
        return cuts;
    }
    static long CalculateNumberOfSlices(int cuts)
    {
        return ((cuts*(long)cuts) + cuts + 2) / 2;
    }
}