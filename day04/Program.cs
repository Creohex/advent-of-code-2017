using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace day04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountValidPassPhrases(File.ReadAllLines("Input.txt")));
            Console.WriteLine(CountValidNoAnagramPassPhrases(File.ReadAllLines("Input2.txt")));
            Console.ReadKey();
        }

        // part 1:
        static int CountValidPassPhrases(string[] input)
        {
            return input.Select(_ => Regex.Split(_, @"\s")).Count(_ => _.Distinct().Count() == _.Count());            
        }

        // part 2:
        static int CountValidNoAnagramPassPhrases(string[] input)
        {
            return input.Select(_ => Regex.Split(_, @"\s")).Count(_ => _.Distinct().Count() == _.Count() && !ContainsAnagrams(_));
        }

        static bool ContainsAnagrams(string[] phraseSet)
        {
            return phraseSet.Select(_ => String.Concat(_.OrderBy(c => c))).Distinct().Count() != phraseSet.Count();
        }
    }
}
