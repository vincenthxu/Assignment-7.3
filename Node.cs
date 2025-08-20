namespace Assignment_7._3
{
    public class Node<T> : IComparable<Node<T>>
    {
        #region Properties
        public T Value { get; set; }
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }
        #endregion

        #region Constructors
        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
        #endregion

        #region Methods
        public int CompareTo(Node<T>? other)
        {
            return Comparer<T>.Default.Compare(Value, other.Value);
        }
        public override string? ToString()
        {
            return Value?.ToString();
        }
        #endregion
    }
}
