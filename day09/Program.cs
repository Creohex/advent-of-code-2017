using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountGroups(File.ReadAllText("Input.txt")));
            Console.WriteLine(CountGarbage(File.ReadAllText("Input.txt")));
            Console.ReadKey();
        }

        // part 1:
        static int CountGroups(string input)
        {
            int total = 0;
            Stack<int> groups = new Stack<int>(), garbage = new Stack<int>();
            for (int i = 0; i < input.Count(); i++)
                switch (input[i])
                {
                    case '{':
                        if (garbage.Count == 0)
                            groups.Push(i);
                        break;
                    case '}':
                        if (garbage.Count == 0)
                        {
                            total += groups.Count();
                            groups.Pop();
                        } break;
                    case '<':
                        if (garbage.Count == 0)
                            garbage.Push(i);
                        break;
                    case '>':
                        garbage.Pop(); break;
                    case '!':
                        i++; break;
                    default: break;
                }
            return total;
        }

        // part 2:
        static int CountGarbage(string input)
        {
            int total = 0;
            Stack<int> garbage = new Stack<int>();
            int negatives = 0;
            for (int i = 0; i < input.Count(); i++)
            {
                switch (input[i])
                {
                    case '<':
                        if (garbage.Count == 0)
                            garbage.Push(i);
                        break;
                    case '>':
                        if (garbage.Count() == 1)
                        {
                            total += i - garbage.Pop() - 1;
                            if (negatives > 0)
                            {
                                total -= 2 * negatives;
                                negatives = 0;
                            }
                        }
                        break;
                    case '!':
                        i++;
                        negatives++; break;
                    default: break;
                }
            }
            return total;
        }
    }
}
