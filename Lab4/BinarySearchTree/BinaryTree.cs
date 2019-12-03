using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace BinarySearchTree
{
    public class BinaryTree
    {
        public Node GlobalRoot { get; private set; }

        public BinaryTree()
        {
            GlobalRoot = null;
        }

        public void Insert(int value)
        {
            if (GlobalRoot == null)
            {
                GlobalRoot = new Node(value);
            }
            else
            {
                Insert(GlobalRoot, value);
            }
        }

        private static Node Insert(Node root, int value)
        {
            if (root == null)
            {
                root = new Node(value);
            }
            else
            {
                if (value.CompareTo(root.Value) <= 0)
                {
                    root.Left = Insert(root.Left, value);
                }
                else
                {
                    root.Right = Insert(root.Right, value);
                }
            }

            return root;
        }

        public Node FindNode(int value)
        {
            var result = FindNode(GlobalRoot, value);

            return result;
        }

        private static Node FindNode(Node root, int value)
        {
            Node result = null;
            if (value < root.Value && root.Left != null)
            {
                result = FindNode(root.Left, value);
            }

            if (value == root.Value)
            {
                return root;
            }

            if (value > root.Value && root.Right != null)
            {
                result = FindNode(root.Right, value);
            }

            return result;
        }

        public IEnumerable<int> PreOrder()
        {
            if(GlobalRoot == null) yield break;

            foreach (var node in PreOrder(GlobalRoot))
            {
                yield return node;
            }
        }

        private static IEnumerable<int> PreOrder(Node root)
        {
            if(root == null) yield break;
            yield return root.Value;
            foreach (var v in PreOrder(root.Right))
            {
                yield return v;
            }
            foreach (var v in PreOrder(root.Left))
            {
                yield return v;
            }
        }

        public IEnumerable<int> InOrder()
        {
            if(GlobalRoot == null) yield break;
            foreach (var node in InOrder(GlobalRoot))
            {
                yield return node;
            }
        }

        private static IEnumerable<int> InOrder(Node root)
        {
            if(root == null) yield break;
            foreach (var v in InOrder(root.Left))
            {
                yield return v;
            }

            yield return root.Value;
            foreach (var v in InOrder(root.Right))
            {
                yield return v;
            }
        }

        public int CountNodes(Node root)
        {
            return root == null ? 0 : CountNodes(root.Left) + CountNodes(root.Right) + 1;
        }

        public int FindKMin(int k, Node node = null)
        {
            Node current = node ?? GlobalRoot;
            int count = k;

            while (current != null)
            {
                var leftTreeSize = CountNodes(current.Left);
                if (leftTreeSize + 1 == count)
                {
                    return current.Value;
                }
                if (leftTreeSize < count)
                {
                    current = current.Right;
                    count -= leftTreeSize + 1;
                }
                else
                {
                    current = current.Left;
                }
            }

            return -1;
        }
        
        private int GetDepth(Node root)
        {
            return root == null ? 0 : Math.Max(GetDepth(root.Left), GetDepth(root.Right)) + 1;
        }

        public Node GetParent(int value)
        {
            Node parent = null;
            Node node = GlobalRoot;
            while (true)
            {
                if (node == null)
                {
                    return null;
                }
                else if (node.Value == value)
                {
                    return parent;
                }
                else
                {
                    parent = node;
                    node = value < node.Value ? node.Left : node.Right;
                }
            }
        }

        public Node LeftRotation(int nodeValue)
        {
            var parentNode = GetParent(nodeValue);
            var node = FindNode(nodeValue);

            if (node == null || node.Right == null)
            {
                return null;
            }

            var oldSubRoot = node;
            node = oldSubRoot.Right;
            oldSubRoot.Right = node.Left;
            node.Left = oldSubRoot;

            if (parentNode == null)
            {
                GlobalRoot = node;
            }
            else if (parentNode.Value < node.Value)
            {
                parentNode.Right = node;
            }
            else
            {
                parentNode.Left = node;
            }

            return node;
        }

        private Node RightRotation(int nodeValue)
        {
            var parentNode = GetParent(nodeValue);
            var node = FindNode(nodeValue);

            if (node == null || node.Left == null)
            {
                return null;
            }

            var oldSubRoot = node;
            node = oldSubRoot.Left;
            oldSubRoot.Left = node.Right;
            node.Right = oldSubRoot;

            if (parentNode == null)
            {
                GlobalRoot = node;
            }
            else if (parentNode.Value < node.Value)
            {
                parentNode.Right = node;
            }
            else
            {
                parentNode.Left = node;
            }

            return node;
        }

        private Node PlaceInRoot(int nodeValue, Node root)
        {
            if (root == null || root.HasNoChild())
            {
                return null;
            }

            var parent = GetParent(nodeValue);
            var node = FindNode(nodeValue);

            while (parent != null && node != null && !node.HasDirectChild(root))
            {
                if (node.Value < parent.Value)
                {
                    node = RightRotation(parent.Value);
                }
                else
                {
                    node = LeftRotation(parent.Value);
                }

                parent = GetParent(node.Value);
                node = FindNode(node.Value);
            }

            return node;
        }

        public bool IsBalanced()
        {
            if (GlobalRoot == null || CountNodes(GlobalRoot) == 1)
            {
                return true;
            }
            
            return Math.Abs(GetDepth(GlobalRoot.Left) - GetDepth(GlobalRoot.Right)) <= 1;
        }

        public void BalanceTree()
        {
            BalanceTree(GlobalRoot);
        }

        private void BalanceTree(Node node)
        {
            if (node == null) return;

            var count = CountNodes(node);

            if (count <= 1) return;

            var minIndex = count / 2 == 0 ? count / 2 : count / 2 + 1;
            
            var minValue = FindKMin(minIndex, node);
            if (minValue != node.Value)
            {
                Node newSubTreeRoot = PlaceInRoot(minValue, node);

                BalanceTree(newSubTreeRoot.Left);
                BalanceTree(newSubTreeRoot.Right);
            }
        }
    }
}
