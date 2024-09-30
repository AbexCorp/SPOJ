using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static int[] primeNumbers;
    static int numberOfPrimes = 1000000-1;

    static void Main(string[] args)
    {
        FindPrimes();
        StringBuilder sb = new StringBuilder();
        int cases = int.Parse(Console.ReadLine());
        for(int i = 1; i <= cases; i++)
        {
            sb.AppendLine($"Case {i}: {FindMultiplicators(int.Parse(Console.ReadLine()))}");
        }
        Console.WriteLine(sb.ToString());
    }

    static void FindPrimes()
    {
        ValueTuple<int, bool>[] primes = new ValueTuple<int, bool>[1000001];

        for(int i = 2; i < primes.Length; i++)
        {
            primes[i].Item1 = i;
            primes[i].Item2 = true;
        }

        for (int i = 2; i < primes.Length; i++)
        {
            if (primes[i].Item2 == false)
            {
                numberOfPrimes--;
                continue;
            }
            for(int j = 2; j < primes.Length; j++)
            {
                if (i * j >= primes.Length)
                    break;
                primes[i * j].Item2 = false;
            }
        }

        primeNumbers = new int[numberOfPrimes];
        int counter = 0;
        for( int i = 0; i < primes.Length; i++)
        {
            if(primes[i].Item2 == true)
            {
                primeNumbers[counter] = i;
                counter++;
            }
        }
    }
    static string FindMultiplicators(int number)
    {
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < primeNumbers.Length; i++)
        {
            if(number % primeNumbers[i] == 0)
            {
                sb.Append($"{primeNumbers[i]} ");
                number = number / primeNumbers[i];
            }
            if (number == 0)
                break;
        }
        return sb.ToString().Trim();
    }
}