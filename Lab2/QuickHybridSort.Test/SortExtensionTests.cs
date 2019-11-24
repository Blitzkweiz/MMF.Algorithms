using System;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading;

namespace QuickHybridSort.Test
{
    public class Tests
    {
        [TestCase(100000, 100000, 12)]
        [TestCase(100000, 1000000, 12)]
        [TestCase(100000, 10000000, 12)]
        [TestCase(1000000, 100000, 12)]
        [TestCase(1000000, 1000000, 12)]
        [TestCase(1000000, 10000000, 12)]
        [TestCase(10000000, 100000, 12)]
        [TestCase(10000000, 1000000, 12)]
        [TestCase(10000000, 10000000, 12)]
        public void HybridSortTimeTest(int length, int maxElement, int k)
        {
            var sw = new Stopwatch();
            var rand = new Random();
            int[] actual1 = new int[length];
            int[] actual2 = new int[length];
            int[] actual3 = new int[length];
            int[] expected = new int[length];
            for (var i = 0; i < length; i++)
            {
                actual1[i] = rand.Next(maxElement);
            }
            Array.Copy(actual1, expected, actual1.Length);
            Array.Copy(actual1, actual2, actual1.Length);
            Array.Copy(actual1, actual3, actual1.Length);
            
            sw.Start();
            SortExtension.HybridSort(actual1, 0, actual1.Length - 1, k);
            sw.Stop();
            System.Console.WriteLine($"HybridSort time is {sw.ElapsedMilliseconds}ms");
            
            sw.Restart();
            SortExtension.RightQuickSort(actual2, 0, actual2.Length - 1);
            sw.Stop();
            System.Console.WriteLine($"RightQuickSort time is {sw.ElapsedMilliseconds}ms");
            
            sw.Restart();
            SortExtension.RandomQuickSort(actual3, 0, actual3.Length - 1);
            sw.Stop();
            System.Console.WriteLine($"RandomQuickSort time is {sw.ElapsedMilliseconds}ms");
            
            sw.Restart();
            Array.Sort(expected);
            sw.Stop();
            System.Console.WriteLine($"Library sort time is {sw.ElapsedMilliseconds}ms");
            
            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);
            Assert.AreEqual(expected, actual3);
        }

        [TestCase(100000, 100000, 12)]
        [TestCase(100000, 1000000, 12)]
        [TestCase(100000, 10000000, 12)]
        [TestCase(1000000, 100000, 12)]
        [TestCase(1000000, 1000000, 12)]
        [TestCase(1000000, 10000000, 12)]
        [TestCase(10000000, 100000, 12)]
        [TestCase(10000000, 1000000, 12)]
        [TestCase(10000000, 10000000, 12)]
        public void HybridKTest(int length, int maxElement, int k)
        {
            var sw = new Stopwatch();
            var rand = new Random();
            int[] actual1 = new int[length];
            int[] expected = new int[length];
            for (var i = 0; i < length; i++)
            {
                actual1[i] = rand.Next(maxElement);
            }
            Array.Copy(actual1, expected, actual1.Length);
            
            sw.Start();
            SortExtension.HybridSort(actual1, 0, actual1.Length - 1, k);
            sw.Stop();
            System.Console.WriteLine($"HybridSort time is {sw.ElapsedMilliseconds}ms");
            
            sw.Restart();
            Array.Sort(expected);
            sw.Stop();
            System.Console.WriteLine($"Library sort time is {sw.ElapsedMilliseconds}ms");
            
            Assert.AreEqual(expected, actual1);
        }
    }
}