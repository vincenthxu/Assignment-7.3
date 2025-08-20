namespace Assignment_7._3
{
    public class BinaryTree<T>
    {
        #region Fields
        private Node<T>? root;
        private int count;
        #endregion

        #region Properties
        public Node<T>? Root => root;
        public int Count => count;
        #endregion

        #region Constructors
        public BinaryTree()
        {
            root = null;
            count = 0;
        }
        #endregion

        #region Methods
        public void Insert(T[] values)
        {
            foreach (var item in values)
            {
                Insert(item);
            }
        }
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
        public void InOrderTraversal() => InOrderTraversal(Root);
        public static void InOrderTraversal(BinaryTree<T> tree) => InOrderTraversal(tree.Root);
        public static void InOrderTraversal(Node<T>? current)
        {
            if (current != null)
            {
                InOrderTraversal(current.Left);
                Console.Write($"{current} ");
                InOrderTraversal(current.Right);
            }
        }
        public void PreOrderTraversal() => PreOrderTraversal(Root);
        public static void PreOrderTraversal(BinaryTree<T> tree) => PreOrderTraversal(tree.Root);
        public static void PreOrderTraversal(Node<T>? current)
        {
            if (current != null)
            {
                Console.Write($"{current} ");
                PreOrderTraversal(current.Left);
                PreOrderTraversal(current.Right);
            }
        }
        public void PostOrderTraversal() => PostOrderTraversal(Root);
        public static void PostOrderTraversal(BinaryTree<T> tree) => PostOrderTraversal(tree.Root);
        public static void PostOrderTraversal(Node<T>? current)
        {
            if(current != null)
            {
                PostOrderTraversal(current.Left);
                PostOrderTraversal(current.Right);
                Console.Write($"{current} ");
            }
        }
        #endregion
    }
}
