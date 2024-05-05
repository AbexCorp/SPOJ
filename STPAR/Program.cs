using System;
using System.Text;

namespace STPAR
{
    class Program
    {
        public static StringBuilder sb = new StringBuilder();

        public static Queue<int> exit = new Queue<int>();
        public static Stack<int> sideStreet = new Stack<int>();
        static int min;


        public static void Main()
        {
            int carNumber;
            while((carNumber = int.Parse(Console.ReadLine())) != 0)
            {
                int[] cars = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
                min = 0;
                for (int i = 0; i  < cars.Length; i++)
                {
                    while(sideStreet.Count != 0)
                    {
                        if (sideStreet.Peek() == min + 1)
                        {
                            exit.Enqueue(sideStreet.Pop());
                            min++;
                        }
                        else
                            break;
                    }
                    if (cars[i] == min + 1)
                    {
                        exit.Enqueue(cars[i]);
                        min++;
                    }
                    else
                    {
                        sideStreet.Push(cars[i]);
                    }
                }
                while(sideStreet.Count != 0)
                {
                    if (sideStreet.Peek() == min + 1)
                    {
                        exit.Enqueue(sideStreet.Pop());
                        min++;
                    }
                    else
                        break;
                }

                if (sideStreet.Count == 0)
                    sb.AppendLine("yes");
                else
                    sb.AppendLine("no");

                exit.Clear();
                sideStreet.Clear();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}