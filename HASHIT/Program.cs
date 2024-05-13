using System;
using System.Text;

class Program
{
    static string?[] hashTable = new string?[101];
    static StringBuilder output = new StringBuilder();

    static void Main()
    {
        int testCases = int.Parse(Console.ReadLine());

        for (int i = 0; i < testCases; i++)
        {
            hashTable = new string?[101];
            int operations = int.Parse(Console.ReadLine());
            int entries = 0;

            for (int j = 0; j < operations; j++)
            {
                string[] input = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
                int hash = Hash(input[1]);
                switch (input[0])
                {
                    case "ADD":
                        if (Add(input[1], hash))
                            entries++;
                        break;

                    case "DEL":
                        if (Remove(input[1], hash))
                            entries--;
                        break;
                }
            }

            output.AppendLine(entries.ToString());
            for (int j = 0; j < 101; j++)
            {
                if (hashTable[j] != null)
                    output.AppendLine($"{j}:{hashTable[j]}");
            }
        }

        Console.WriteLine(output);
    }

    static int Hash(string key)
    {
        int sum = 0;
        for (int i = 0; i < key.Length; i++)
        {
            sum += (key[i] * (i + 1));
        }
        sum *= 19;

        return sum % 101;
    }

    static bool Add(string key, int hash)
    {
        if (Find(key) != null)
            return false;

        if (hashTable[hash] == null)
        {
            hashTable[hash] = key;
            return true;
        }

        int? newHash = Conflict(hash);
        if (newHash == null)
            return false;

        hashTable[newHash.Value] = key;
        return true;
    }

    static bool Remove(string key, int hash)
    {
        int? index = Find(key);
        if (index == null)
            return false;

        hashTable[index.Value] = null;
        return true;
    }

    static int? Find(string key)
    {
        int hash = Hash(key);
        for (int i = 0; i < 20; i++)
        {
            int index = (hash + i * i + 23 * i) % 101;
            if (hashTable[index] == key)
                return index;
        }
        return null;
    }

    static int? Conflict(int hash)
    {
        for (int i = 1; i <= 19; i++)
        {
            int newHash = (hash + i * i + 23 * i) % 101;
            if (hashTable[newHash] == null)
                return newHash;
        }
        return null;
    }

    static void PrintResult(int entries)
    {
        Console.WriteLine(entries);
        for (int i = 0; i < 101; i++)
        {
            if (hashTable[i] != null)
                Console.WriteLine($"{i}:{hashTable[i]}");
        }
    }
}