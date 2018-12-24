using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RunInstructions(File.ReadAllLines("Input.txt")));
            Console.WriteLine(RunWeirdInstructions(File.ReadAllLines("Input2.txt")));
            Console.ReadKey();
        }

        // part 1:
        static int RunInstructions(string[] input)
        {
            int[] instructions = input.Select(_ => Int32.Parse(_)).ToArray();
            int steps = 0;
            int prevIndex = 0;
            int index = 0;

            while (index >= 0 && index < instructions.Length)
            {
                steps++;
                prevIndex = index;
                index = instructions[index] + index;
                instructions[prevIndex]++;
            }

            return steps;
        }

        // part 2:
        static int RunWeirdInstructions(string[] input)
        {
            int[] instructions = input.Select(_ => Int32.Parse(_)).ToArray();
            int steps = 0;
            int prevIndex = 0;
            int index = 0;

            while (index >= 0 && index < instructions.Length)
            {
                steps++;
                prevIndex = index;
                index = instructions[index] + index;
                instructions[prevIndex] += instructions[prevIndex] >= 3 ? -1 : 1;
            }

            return steps;
        }
    }
}
