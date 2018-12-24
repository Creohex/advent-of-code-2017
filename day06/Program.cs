using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountCycles(File.ReadAllText("Input.txt")).Count - 1);
            Console.WriteLine(CountNextRedistributionCycles(File.ReadAllText("Input2.txt")));
            Console.ReadKey();
        }

        // part 1:
        static List<int[]> CountCycles(string input)
        {
            int[] currentState = Array.ConvertAll(Regex.Split(input, @"\t").ToArray(), i => Int32.Parse(i));
            List<int[]> log = new List<int[]>();
            while (log.FirstOrDefault(_ => currentState.SequenceEqual(_)) == null)
            {
                log.Add(currentState.ToArray());
                int biggestBlock = Array.IndexOf(currentState, currentState.Max());
                int biggestValue = currentState[biggestBlock];
                currentState[biggestBlock] = 0;
                for (int i = biggestBlock + 1; i < biggestBlock + biggestValue + 1; i++)
                    currentState[i % currentState.Count()]++;
            }
            log.Add(currentState.ToArray());
            return log;
        }

        // part 2:
        static int CountNextRedistributionCycles(string input)
        {
            List<int[]> log = CountCycles(input);
            int previousCycles = log.Count();
            int[] stateInQuestion = log.Last().ToArray(), currentState = stateInQuestion.ToArray();
            while (log.Count(_ => _.SequenceEqual(stateInQuestion)) != 3)
            {
                int biggestBlock = Array.IndexOf(currentState, currentState.Max());
                int biggestValue = currentState[biggestBlock];
                currentState[biggestBlock] = 0;
                for (int i = biggestBlock + 1; i < biggestBlock + biggestValue + 1; i++)
                    currentState[i % currentState.Count()]++;
                log.Add(currentState.ToArray());
            }
            return log.Count - previousCycles;
        }
    }
}
