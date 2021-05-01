using System;

namespace HashTable
{
    public class Item
    {
        public int Key { get; private set; }
        public int Value { get; private set; }

        public Item(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }
}