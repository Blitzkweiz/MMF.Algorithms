using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace HuffmanAlgorithm
{
    public class HuffmanTree
    {
        public Node GlobalRoot { get; set; }
        
        public Dictionary<char, BitArray> Map { get; set; }

        public HuffmanTree(string text)
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (!freq.ContainsKey(text[i]))
                {
                    freq.Add(text[i], 0);
                }

                freq[text[i]]++;
            }

            List<Node> list = new List<Node>();
            foreach (var ch in freq)
            {
                list.Add(new Node(ch.Key, ch.Value));
            }
            list.Sort((x, y) => x.Frequency - y.Frequency);
            
            while (list.Count != 1)
            {
                Node left = list[0];
                Node right = list[1];
                list.RemoveRange(0, 2);

                int sum = left.Frequency + right.Frequency;
                list.Insert(FindListIndex(list, left.Frequency + right.Frequency), new Node('\0', sum, left, right));
            }

            GlobalRoot = list[0];
        }

        private int FindListIndex(List<Node> list, int frequency)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Frequency > frequency)
                {
                    return i;
                }
            }

            return list.Count;
        }

        public void CodeFile(string sourceFilePath, string newFilePath)
        {
            Byte byt;
            var binCode = new List<BitArray>();
            using (var sr = new StreamReader(sourceFilePath))
            {
                while (sr.Peek() >= 0)
                {
                    binCode.Add(Map[(char)sr.Read()]);
                }
            }

            using (var sw = new StreamWriter(newFilePath))
            {
                foreach (var bitArray in binCode)
                {
                    foreach (var bit in bitArray.Cast<bool>())
                    {
                        sw.Write(bit ? 1 : 0);
                    }
                }
            }
        }

        public StringBuilder Encode(string text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                foreach (var bit in Map[text[i]].Cast<bool>())
                {
                    stringBuilder.Append(bit ? "1" : "0");
                }
            }

            return stringBuilder;
        }

        public void DecodeFile(string sourceFilePath, string newFilePath)
        {
            Node current = GlobalRoot;
            StringBuilder stringBuilder = new StringBuilder();
            using (var sr = new StreamReader(sourceFilePath))
            {
                while (sr.Peek() >= 0)
                {
                    current = (char) sr.Read() == '1' ? current.Right : current.Left;
                    if (current.Left == null && current.Right == null)
                    {
                        stringBuilder.Append(current.Ch);
                        current = GlobalRoot;
                    }
                }
            }

            using (var sw = new StreamWriter(newFilePath))
            {
                sw.Write(stringBuilder.ToString());
            }
        }

        public StringBuilder Decode(StringBuilder text)
        {
            StringBuilder sb = new StringBuilder();
            
            Node current = GlobalRoot;
            for (int i = 0; i < text.Length; i++)
            {
                current = text[i] == '1' ? current.Right : current.Left;
                if (current.Left == null && current.Right == null)
                {
                    sb.Append(current.Ch);
                    current = GlobalRoot;
                }
            }

            return sb;
        }

        public void FindMap()
        {
            var map = new Dictionary<char, BitArray>();
            FindMap(GlobalRoot, "", map);

            Map = map;
        }

        private void FindMap(Node root, string str, Dictionary<char, BitArray> map)
        {
            if (root == null) return;
            if (root.Left == null && root.Right == null)
            {
                var bitArray = new BitArray(str.Length);
                for (int i = 0; i < str.Length; i++)
                {
                    bitArray[i] = str[i] - '0' == 1;
                }
                map.Add(root.Ch, bitArray);
            }

            FindMap(root.Left, str + "0", map);
            FindMap(root.Right, str + "1", map);
        }
        
        public IEnumerable<Node> PreOrder()
        {
            if(GlobalRoot == null) yield break;
        
            foreach (var node in PreOrder(GlobalRoot))
            {
                yield return node;
            }
        }
        
        private static IEnumerable<Node> PreOrder(Node root)
        {
            if(root == null) yield break;
            yield return root;
            foreach (var v in PreOrder(root.Right))
            {
                yield return v;
            }
            foreach (var v in PreOrder(root.Left))
            {
                yield return v;
            }
        }
    }
}