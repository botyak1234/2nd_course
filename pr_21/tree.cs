using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace heeelp
{
    public class BinaryTree 
    {
        
        private class Node
        {
            public int inf; 
            public Node left; 
            public Node right; 
            public Node(int nodeInf)
            {
                inf = nodeInf;
                left = null;
                right = null;
            }
            
            public static void Add(ref Node r, int nodeInf)
            {
                if (r == null)
                {
                    r = new Node(nodeInf);
                }
                else
                {
                    if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0)
                    {
                        Add(ref r.left, nodeInf);
                    }
                    else
                    {
                        Add(ref r.right, nodeInf);
                    }
                }
            }

            public static int FindMin(Node r)
            {
                if (r == null)
                {
                    return int.MaxValue; // Возвращаем максимальное значение, чтобы обработать случай отсутствия листьев.
                }

                if (r.left == null && r.right == null)
                {
                    return r.inf;
                }

                int leftMin = FindMin(r.left);
                int rightMin = FindMin(r.right);

                return Math.Min(leftMin, rightMin);
            }

            public static void Preorder(Node r)
            {
                if (r != null)
                {
                    Console.Write("{0} ", r.inf);
                    Preorder(r.left);
                    Preorder(r.right);
                }
            }


        }

        Node tree;
        public int Inf
        {
            set { tree.inf = value; }
            get { return tree.inf; }
        }
        public BinaryTree() 
        {
            tree = null;
        }
        private BinaryTree(Node r) 
        {
            tree = r;
        }
        public void Add(int nodeInf) 
        {
            Node.Add(ref tree, nodeInf);
        }


        public int FindMin()
        {
            return Node.FindMin(tree);
        }

        public void Preorder()
        {
            Node.Preorder(tree);
        }

    }
}
