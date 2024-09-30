using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

class Program
{
    const int mod = 1000000007;
    static int[] fac = new int[1000001];

    static void Main(string[] args)
    {
        Factorial();
        StringBuilder sb = new StringBuilder();
        string inputLine = "a";
        while( (inputLine = Console.ReadLine()) != null )
        {
            sb.AppendLine( FindCombinations(inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToString() );
        }
        Console.WriteLine(sb.ToString());
    }

    static void Factorial()
    {
        fac[0] = 1;
        for(int i = 1; i < fac.Length; i++)
        {
            fac[i] = (int)(((long)fac[i-1] * i) % mod);
        }
    }

    static int FindCombinations(string[] numbers)
    {
        int numberOfSchools = int.Parse(numbers[0]); //n
        int participatingSchools = int.Parse(numbers[1]); //a
        int numberOfStudents = int.Parse(numbers[2]); //b
        int participatingStudents = int.Parse(numbers[3]); //d


        int result = fac[numberOfSchools];
        int temp = ModInverse( (int)((fac[participatingSchools] * (long)fac[numberOfSchools - participatingSchools]) % mod));
        result = (int)((result * (long)temp) % mod);
        temp = ModInverse( (int)((fac[participatingStudents] * (long)fac[numberOfStudents - participatingStudents]) % mod));
        temp = (int)((fac[numberOfStudents] * (long)temp) % mod);
        result = (int)((result * ModPow(temp, participatingSchools)) % mod);


        return result;
    }

    static int ModInverse(int baseNumber, int modulo = mod)
    {
        int originalModulo = modulo;
        int previous = 0;
        int current = 1;

        while (baseNumber > 1)
        {
            int q = baseNumber / modulo;
            int t = modulo;

            modulo = baseNumber % modulo;
            baseNumber = t;
            t = previous;

            previous = current - q * previous;
            current = t;
        }

        if (current < 0)
            current += originalModulo;

        return current;
    }

    static long ModPow(long baseNumber, int power)
    {
        long result = 1;
        while (power > 0)
        {
            if ((power & 1) == 1)
            {
                result = (result * baseNumber) % mod;
            }
            baseNumber = (baseNumber * baseNumber) % mod;
            power >>= 1;
        }
        return result;
    }
}