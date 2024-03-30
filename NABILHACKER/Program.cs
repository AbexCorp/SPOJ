using System;
using System.Text;

namespace NABILHACKER
{
    class Program
    {
        public static void Main()
        {
            StringBuilder sb = new StringBuilder();
            int testCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                string input = Console.ReadLine();
                sb.AppendLine(ReadPassword(ref input));
            }
            Console.WriteLine(sb.ToString());
        }

        static StringBuilder password = new StringBuilder();
        private static string ReadPassword(ref string pass)
        {
            Node start = new Node();
            Node current = start;
            Node? prev = current.Prev;
            Node? next = current.Next;
            foreach(char c in pass)
            {
                switch (c)
                {
                    case '<':
                        if(current.character is null && (current.Prev is null || current.Prev.character is null)) //Already before leftmost character
                            break;
                        else if(current.character is null) //After rightmost character
                        {
                            if(current.Prev.Prev is null) //If passes left most character
                            {
                                current.Prev.Prev = new Node(next:current.Prev);
                                start = current.Prev.Prev;
                            }
                            current = current.Prev.Prev;
                            prev = current.Prev;
                            next = current.Next;
                        }
                        else if(!(current.character is null) && current.Prev is null) //On leftmost character
                        {
                            current.Prev = new Node(next:current);
                            current = current.Prev;
                            prev = current.Prev;
                            next = current.Next;
                            start = current;
                        }
                        else //Every other position
                        {
                            current = current.Prev;
                            prev = current.Prev;
                            next = current.Next;
                        }
                        break;

                    case '>':
                        if(current.character is null && (current.Next is null || current.Next.character is null)) //Already after rightmost character
                            break;
                        else if(!(current.character is null) && current.Next is null) //On leftmost character
                        {
                            current.Next = new Node(prev:current);
                            current = current.Next;
                            prev = current.Prev;
                            next = current.Next;
                        }
                        else //Every other position
                        {
                            current = current.Next;
                            prev = current.Prev;
                            next = current.Next;
                        }
                        break;

                    case '-':
                        if(current.character is null && (current.Prev is null || current.Prev.character is null)) //Already before leftmost character
                            break;
                        else if(current.character is null) //After rightmost character
                        {
                            if (current.Prev.Prev is null) //If passes left most character
                            {
                                current.Prev.Prev = new Node(next: current.Prev);
                                start = current.Prev.Prev;
                            }
                            current = current.Prev.Prev;
                            current.Next = new Node(prev:current);
                            prev = current.Prev;
                            next = current.Next;
                        }
                        else if(!(current.character is null) && current.Prev is null) //On leftmost character
                        {
                            current.character = null;
                        }
                        else //Every other position
                        {
                            current.Prev.Next = current.Next;
                            current.Next.Prev = current.Prev;
                            current = current.Prev;
                        }
                        break;

                    default:
                        if (current.character is null) //Before leftmost character
                        {
                            current.character = c;
                            if(current.Next is null || current.Next.character is null)
                            {
                                prev = current;
                                current.Next = new Node(prev:current);
                                current = current.Next;
                                next = current.Next;
                            }
                        }
                        else //Every other position
                        {
                            current.Next = new Node(c, prev:current);
                            current.Next.Next = next;
                            next.Prev = current.Next;
                            prev = current;
                            current.Next = current.Next is null ? new Node(prev: current) : current.Next;
                            current = current.Next;
                            next = current.Next;
                        }
                        break;
                }
            }

            password.Clear();
            current = start;
            while (true)
            {
                password.Append(current.character);
                if(current.Next is null)
                    break;
                current = current.Next;
            }
            return password.ToString();
        }
    }

    public class Node
    {
        public char? character;
        public Node? Next {get; set;}
        public Node? Prev {get; set;}
        public Node(char? character = null, Node next = null, Node prev = null) {
            this.character = character;
            Next = next;
            Prev = prev;
        }
    }
}