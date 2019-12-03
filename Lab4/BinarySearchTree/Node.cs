namespace BinarySearchTree
{
    public class Node
    {
        public int Value { get; set; }
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Value = value;
        }

        public bool HasDirectChild(Node node)
        {
            return this.Left == node || this.Right == node;
        }

        public bool HasNoChild()
        {
            return this.Left == null && this.Right == null;
        }
    }
}