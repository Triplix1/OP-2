using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public static class Funcs
    {
        public static void Output(TreeNode root, int n = 0)
        {
            if (root != null)
            {
                Output(root.Right, n + 5);
                for (int i = 0; i < n; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(root.Value);
                Output(root.Left, n + 5);
            }
        }
        public static Tree GenerateTree()
        {
            var tree = new Tree();
            var nodes = Input();
            foreach (var node in nodes)
            {
                tree.Add(node);
            }
            return tree;
        }

        public static List<double> Input()
        {
            List<double> result = new List<double>();
            Console.WriteLine("Enter your tree:");
            string tree = Console.ReadLine();
            while (!IsNormalTree(tree))
            {
                Console.WriteLine("Enter normal tree!!!");
                tree = Console.ReadLine();
            }
            foreach (var node in tree.Trim().Split())
            {
                result.Add(Convert.ToDouble(node));
            }
            return result;
        }
        public static bool IsNormalTree(string tree)
        {
            if(tree == string.Empty)
            {
                return false;
            }                

            string[] nodes = tree.Trim().Split();
            for (int i = 0; i < nodes.Length; i++)
            {
                if (!double.TryParse(nodes[i], out double tmp))
                {
                    return false;
                }                
            }
            return true;
        }

        public static double GetAverage(Tree root)
        {
            int number = 0;
            double sum = 0;
            FindSumAndNum(root.Root, ref number, ref sum);
            return sum / number;
        }
        public static void FindSumAndNum(TreeNode node, ref int number, ref double sum)
        {
            if (node == null)
                return;

            number++;

            FindSumAndNum(node.Left, ref number, ref sum);

            sum += node.Value;          

            FindSumAndNum(node.Right, ref number, ref sum);
        }
    }
}
