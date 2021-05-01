using System.Collections.Generic;
using System.Dynamic;

namespace HashTable
{
    public class ChainsHashTable
    {
        public List<List<Item>> Table { get; private set; }

        public int Capacity { get; private set; }
        public int Size { get; private set; }

        public ChainsHashTable(int capacity)
        {
            Capacity = capacity;
            Size = 0;
            
            Table = new List<List<Item>>();

            for (int i = 0; i < Capacity; i++)
            {
                Table.Add(new List<Item>());
            }
        }

        public void Put(int key, int value)
        {
            
        }
    }
}