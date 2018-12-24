using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace day02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CheckSum(File.ReadAllLines("Input.txt")));
            Console.WriteLine(ComplicatedCheckSum(File.ReadAllLines("Input2.txt")));
            Console.ReadKey();
        }

        // part 1:
        static int CheckSum(string[] s)
        {
            return s.Select(_ => Regex.Split(_, @"\t").Select(v => Convert.ToInt32(v)))
                .Sum(_ => _.Max() - _.Min());
        }

        // part 2:
        static int ComplicatedCheckSum(string[] s)
        {
            return s.Select(_ => Regex.Split(_, @"\s").Select(v => Convert.ToInt32(v)))
                .Sum(_ => _.Sum(num => _.Sum(t => num <= t ? 0 : (num % t == 0 ? num / t : 0))));
        }
    }
}
