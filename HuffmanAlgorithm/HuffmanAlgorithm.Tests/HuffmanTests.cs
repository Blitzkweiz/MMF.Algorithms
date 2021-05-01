using System;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HuffmanAlgorithm.Tests
{
    public class HuffmanTests
    {
        private HuffmanTree huffmanTree;
        
        [SetUp]
        public void Setup()
        {
            huffmanTree = new HuffmanTree("Huffman coding is a data compression algorithm");
        }

        [Test]
        public void HuffmanAlgorithmTest()
        {
            huffmanTree.FindMap();
            huffmanTree.CodeFile(@"C:\Users\Blitzkweiz_Ithore\MMF.Algorithms\HuffmanAlgorithm\HuffmanAlgorithm.Tests\TestData\SourceFile.txt"
                , @"C:\Users\Blitzkweiz_Ithore\MMF.Algorithms\HuffmanAlgorithm\HuffmanAlgorithm.Tests\TestData\SourceFile2");
            huffmanTree.DecodeFile(@"C:\Users\Blitzkweiz_Ithore\MMF.Algorithms\HuffmanAlgorithm\HuffmanAlgorithm.Tests\TestData\SourceFile2"
            ,@"C:\Users\Blitzkweiz_Ithore\MMF.Algorithms\HuffmanAlgorithm\HuffmanAlgorithm.Tests\TestData\ResultFile.txt");
        }
    }
}