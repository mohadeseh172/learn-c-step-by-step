using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTraversal
{
    // Binary Tree Node Class
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    // Binary Tree Class
    public class BinaryTree
    {
        public TreeNode Root { get; private set; }

        public BinaryTree()
        {
            Root = null;
        }

        // Add a new node to the tree
        public void Add(int value)
        {
            Root = AddRecursive(Root, value);
        }

        private TreeNode AddRecursive(TreeNode node, int value)
        {
            if (node == null)
            {
                return new TreeNode(value);
            }

            if (value < node.Value)
            {
                node.Left = AddRecursive(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = AddRecursive(node.Right, value);
            }

            return node;
        }

        // Preorder Traversal: Root -> Left -> Right
        public void PreorderTraversal(TreeNode node)
        {
            if (node == null) return;

            Console.Write(node.Value + " ");
            PreorderTraversal(node.Left);
            PreorderTraversal(node.Right);
        }

        // Inorder Traversal: Left -> Root -> Right
        public void InorderTraversal(TreeNode node)
        {
            if (node == null) return;

            InorderTraversal(node.Left);
            Console.Write(node.Value + " ");
            InorderTraversal(node.Right);
        }

        // Postorder Traversal: Left -> Right -> Root
        public void PostorderTraversal(TreeNode node)
        {
            if (node == null) return;

            PostorderTraversal(node.Left);
            PostorderTraversal(node.Right);
            Console.Write(node.Value + " ");
        }

        // Visualize the binary tree
        public void DisplayTree(TreeNode node, string indent = "", bool isLast = true)
        {
            if (node != null)
            {
                Console.Write(indent);
                Console.Write(isLast ? "└── " : "├── ");
                Console.WriteLine(node.Value);

                indent += isLast ? "    " : "│   ";

                DisplayTree(node.Left, indent, node.Right == null);
                DisplayTree(node.Right, indent, true);
            }
        }
    }

    // Test Program
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            Console.WriteLine("Enter the number of nodes in the binary tree:");
            int nodeCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the values of the nodes:");
            for (int i = 0; i < nodeCount; i++)
            {
                Console.Write($"Value {i + 1}: ");
                int value = int.Parse(Console.ReadLine());
                tree.Add(value);
            }

            Console.WriteLine("\nBinary Tree Structure:");
            tree.DisplayTree(tree.Root);

            int choice;
            do
            {
                Console.WriteLine("\nChoose a traversal method:");
                Console.WriteLine("1. Preorder Traversal");
                Console.WriteLine("2. Inorder Traversal");
                Console.WriteLine("3. Postorder Traversal");
                Console.WriteLine("-1. Exit");

                choice = int.Parse(Console.ReadLine());

                Console.WriteLine("\nTraversal Result:");
                switch (choice)
                {
                    case 1:
                        tree.PreorderTraversal(tree.Root);
                        Console.WriteLine(); // Add a line break after traversal
                        break;
                    case 2:
                        tree.InorderTraversal(tree.Root);
                        Console.WriteLine(); // Add a line break after traversal
                        break;
                    case 3:
                        tree.PostorderTraversal(tree.Root);
                        Console.WriteLine(); // Add a line break after traversal
                        break;
                    case -1:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != -1);
        }
    }
}
