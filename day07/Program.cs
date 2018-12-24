using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day07
{
    class Program
    {
        static List<Node> Tree = new List<Node>();
        static Node Root;

        static void Main(string[] args)
        {
            Console.WriteLine(FindRoot(File.ReadAllLines("Input.txt")));
            Console.WriteLine(Diff(Root));
            Console.ReadKey();
        }

        // part 1:
        static string FindRoot(string[] input)
        {
            foreach (var r in input)
            {
                MatchCollection mc = Regex.Matches(r, @"\w+");
                Node node = new Node();
                for (int i = 0; i < mc.Count; i++)
                    switch (i)
                    {
                        case 0: node.Name = mc[i].ToString(); break;
                        case 1: node.Value = Int32.Parse(mc[i].ToString()); break;
                        default: node.Children.Add(mc[i].ToString()); break;
                    }
                Tree.Add(node);
            }
            return (Root = Tree.FirstOrDefault(_ => Tree.Count(c => c.Children.Contains(_.Name)) == 0)).Name;
        }

        // part 2:
        static int Diff(Node node)
        {
            int[] sums = new int[node.Children.Count];
            List<Node> rootChildren = Tree.Where(_ => node.Children.Contains(_.Name)).ToList();
            for (int i = 0; i < sums.Count(); i++)
                sums[i] = NodeSum(rootChildren[i]);

            if (sums.Distinct().Count() > 1)
                return Diff(rootChildren[UnevenNodeIndex(sums)]);
            else
            {
                Node parent = Tree.FirstOrDefault(_ => _.Children.Contains(node.Name));
                List<Node> troubledGroup = Tree.Where(_ => parent.Children.Contains(_.Name)).ToList();
                sums = new int[parent.Children.Count];
                for (int i = 0; i < sums.Count(); i++)
                    sums[i] = NodeSum(troubledGroup[i]);
                return Math.Abs(sums.Distinct().First() - sums.Distinct().Skip(1).First());
            }
        }

        static int UnevenNodeIndex(int[] nodeSums)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            foreach (int i in nodeSums)
                if (d.Keys.Contains(i))
                    d[i]++;
                else
                    d.Add(i, 1);
            return Array.IndexOf(nodeSums, d.First(_ => _.Value == 1).Key);
        }

        static int NodeSum(Node node)
        {
            int sum = node.Value;
            List<Node> children = Tree.Where(_ => node.Children.Contains(_.Name)).ToList();
            if (children.Count > 0)
                foreach (Node child in children)
                    sum += NodeSum(child);
            return sum;
        }

        class Node
        {
            public string Name { get; set; }
            public int Value { get; set; }
            public List<string> Children { get; set; }
            public Node() { Children = new List<string>(); }
        }
    }
}