namespace Assignment_7._3
{
    public class BinarySearchTree<T> : IBinaryTree<T>
    {
        public delegate void TraversalOperation(Node<T>? value);

        #region Fields
        private Node<T>? root;
        private int count;
        #endregion

        #region Properties
        public Node<T>? Root => root;
        public int Count => count;
        public TraversalOperation Operation { get; set; }
        #endregion

        #region Constructors
        public BinarySearchTree()
        {
            root = null;
            count = 0;
            Operation = (Node<T>? n) => Console.Write($"{n} ");
        }
        #endregion

        #region Methods
        public void Insert(T[] values) => Array.ForEach<T>(values, t => Insert(t));
        public bool Insert(T value) => Insert(new Node<T>(value));
        public bool Insert(Node<T>? newNode)
        {
            Node<T>? insertionPoint = Traverse(newNode);
            count++;
            if (insertionPoint == null)
            {
                root = newNode;
                return true;
            }
            else if (insertionPoint.CompareTo(newNode) == 0)
            {
                count--;
                return false;
            }
            else if (insertionPoint.CompareTo(newNode) > 0)
            {
                insertionPoint.Left = newNode;
            }
            else
            {
                insertionPoint.Right = newNode;
            }
            return true;
        }
        public Node<T>? Search(T value) => Search(new Node<T>(value));
        public Node<T>? Search(Node<T> node)
        {
            Node<T>? result = Traverse(node);
            if (node.CompareTo(result) == 0)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        private Node<T>? Traverse(T value) => Traverse(new Node<T>(value));
        private Node<T>? Traverse(Node<T>? node)
        {
            Node<T>? parent = null;
            Node<T>? current = root;

            int result = 0;
            while (current != null)
            {
                parent = current;
                result = current.CompareTo(node);
                if (result == 0)
                {
                    break;
                }
                else if (result > 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            return parent;
        }
        public void InOrderTraversal() => InOrderTraversal(Root, Operation);
        public static void InOrderTraversal(BinarySearchTree<T> tree) => InOrderTraversal(tree.Root, tree.Operation);
        public static void InOrderTraversal(Node<T>? current, TraversalOperation Operation)
        {
            if (current != null)
            {
                InOrderTraversal(current.Left, Operation);
                Operation(current);
                InOrderTraversal(current.Right, Operation);
            }
        }
        public void PreOrderTraversal() => PreOrderTraversal(Root, Operation);
        public static void PreOrderTraversal(BinarySearchTree<T> tree) => PreOrderTraversal(tree.Root, tree.Operation);
        public static void PreOrderTraversal(Node<T>? current, TraversalOperation Operation)
        {
            if (current != null)
            {
                Operation(current);
                PreOrderTraversal(current.Left, Operation);
                PreOrderTraversal(current.Right, Operation);
            }
        }
        public void PostOrderTraversal() => PostOrderTraversal(Root, Operation);
        public static void PostOrderTraversal(BinarySearchTree<T> tree) => PostOrderTraversal(tree.Root, tree.Operation);
        public static void PostOrderTraversal(Node<T>? current, TraversalOperation Operation)
        {
            if(current != null)
            {
                PostOrderTraversal(current.Left, Operation);
                PostOrderTraversal(current.Right, Operation);
                Operation(current);
            }
        }
        #endregion
    }
}
