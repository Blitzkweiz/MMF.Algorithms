using System;

namespace HashTable
{
    public class Hash
    {
        public static int PrimeHash(int key, int size)
        {
            return key % size;
        }

        public static int HashConst(int key, int size, double a)
        {
            return (int)(size * (key * a - Math.Truncate(key * a)));
        }

        public static int DoubleHash(int key, int size, int i = 0)
        {
            int hash = 0;
            return (hash + i * hash) % size;
        }
    }
}