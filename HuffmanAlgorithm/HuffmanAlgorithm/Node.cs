using System;

namespace HuffmanAlgorithm
{
    public class Node
    {
        public char Ch { get; set; }
        public int Frequency { get; set; }
        
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(char ch, int frequency)
        {
            Ch = ch;
            Frequency = frequency;
            Left = null;
            Right = null;
        }

        public Node(char ch, int frequency, Node left, Node right)
        {
            Ch = ch;
            Frequency = frequency;
            Left = left;
            Right = right;
        }
    }
}