﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main()
    {
        SortedDictionary<int, Number> sortedNumbers = new SortedDictionary<int, Number>();

        Console.ReadLine();
        int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);

        int counter = 1;
        foreach (int number in numbers)
        {
            if (sortedNumbers.ContainsKey(number))
                sortedNumbers[number].amount++;
            else
                sortedNumbers.Add(number, new Number(counter));
            counter++;
        }

        var ordered = sortedNumbers.OrderByDescending(x => x.Value.amount).ThenBy(x => x.Value.appearance);
        foreach(var x in ordered)
        {
            for(int i = 0; i < x.Value.amount; i++)
                Console.Write($"{x.Key} ");
        }
    }
}
public class Number
{
    public int amount = 1;
    public int appearance = 0;
    public Number(int appearance)
    {
        this.appearance = appearance;
    }
}