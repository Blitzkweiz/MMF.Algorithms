using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    public class BinaryTreeTests
    {
        public BinaryTree Bt { get; set; }

        [SetUp]
        public void BinaryTreeInitialization()
        {
            Bt = new BinaryTree();
            Bt.Insert(0);
            Bt.Insert(7);
            Bt.Insert(1);
            Bt.Insert(9);
            Bt.Insert(2);
            Bt.Insert(5);
            Bt.Insert(6);
            Bt.Insert(10);
            Bt.Insert(4);
            Bt.Insert(8); 
            Bt.Insert(3);
        }
        
        [Test]
        public void PreOrderTest()
        {
            List<int> actual = Bt.PreOrder().ToList();

            IEnumerable<int> expected = new List<int> {0, 7, 9, 10, 8, 1, 2, 5, 6, 4, 3 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BalanceTest()
        {
            Bt.BalanceTree();
            foreach (var v in Bt.PreOrder())
            {
                Console.WriteLine(v);
            }
            
            Assert.IsTrue(Bt.IsBalanced());
        }
    }
}