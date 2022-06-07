using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class TreeNode
    {
        public double Value { get; set; }
        TreeNode left;
        TreeNode right;
        public TreeNode Left { get { return left; } set { left = value; } } 
        public TreeNode Right { get { return right; } set { right = value; } }
        public TreeNode(double value)
        {
            Value = value;
        }
    }
    public class Tree
    {
        public TreeNode Root { get; set; }

        public void Add(double value)
        {
            if (Root == null)
            {
                Root = new TreeNode(value);
                return;
            }
            TreeNode before;
            var tmp = Root;
            while (true)
            {
                before = tmp;
                if (value < tmp.Value)
                {
                    tmp = tmp.Left;
                    if (tmp == null)
                    {
                        before.Left = new TreeNode(value);
                        return;
                    }
                }
                else
                {
                    tmp = tmp.Right;
                    if (tmp == null)
                    {
                        before.Right = new TreeNode(value);
                        return;
                    }
                }
            }
        }


    }
}
