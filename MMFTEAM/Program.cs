using System;
using System.Text;

class Program
{
    const int mod = 1000000007;

    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        int inputLine = 1;
        while( (inputLine = int.Parse(Console.ReadLine())) != 0 )
        {
            sb.AppendLine((    (((inputLine * ((long)inputLine - 1)) % mod) * ModPow(2, inputLine - 2)) % mod    ).ToString());
        }
        Console.WriteLine(sb.ToString());
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