using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TreeTraversal
 {
    class Node
    {
        public Node left, right;
        public int data;
        public Node(int data)
        {
            this.data = data;
            left = right = null;
        }
    }


    class Program
    {
        static void postOrder(Node root)
        {
            Node node = root;
            var leftNode = node.left;
            var rightNode = node.right;

            if (leftNode != null)
                postOrder(leftNode);

            if (rightNode != null)
                postOrder(rightNode);

            Console.Write(node.data + " ");
        }

        static void preOrder(Node root)
        {
            Node node = root;
            var leftNode = node.left;
            var rightNode = node.right;

            Console.Write(node.data + " ");

            if (leftNode != null)
                preOrder(leftNode);

            if (rightNode != null)
                preOrder(rightNode);
            
        }

        static void inOrder(Node root)
        {
            Node node = root;
            var leftNode = node.left;
            var rightNode = node.right;

            if (leftNode != null)
                inOrder(leftNode);

            Console.Write(node.data + " ");

            if (rightNode != null)
                inOrder(rightNode);
        }

        static void levelOrder(Node root)
        {
            Queue myQ = new Queue();
            myQ.Enqueue(root);

            while (myQ.Count > 0) {

                Node node = (Node)myQ.Dequeue();
                var leftNode = node.left;
                var rightNode = node.right;

                Console.Write(node.data + " ");

                if (leftNode != null)
                {
                    myQ.Enqueue(leftNode); 
                }

                if (rightNode != null)
                {
                    myQ.Enqueue(rightNode);
                }
            }
        }

        static Node insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.data)
                {
                    cur = insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }

        static void Main(String[] args)
        {
            Node root = null;
            Console.WriteLine(" Enter Root Nodes Count :");
            int T = Int32.Parse(Console.ReadLine());
            Console.WriteLine(" Enter Root Nodes :");
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                root = insert(root, data);
            }
            
            Console.WriteLine(" In Order ");
            inOrder(root);
            Console.WriteLine("\n Post Order ");
            postOrder(root);
            Console.WriteLine("\n Pre Order ");
            preOrder(root);
            Console.WriteLine("\n Level Order ");
            levelOrder(root);

        }
    }
}
