namespace Assignment_7._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Object[]> arrays = new();
            arrays.Add([4, 6, 5, 7, 2, 1, 3, 3]);
            arrays.Add(["d", "b", "a", "c", "f", "e", "g"]);
            arrays.Add([0, 1, 2, 3, 4, 5, 6]);

            List<Object> targets = new();
            targets.Add(2);
            targets.Add("b");
            targets.Add(-1);

            BinaryTree<Object> objectTree;

            var arraysAndTargets = arrays.Zip(targets, (a, t) => new { array = a, target = t });
            // var arraysAndTargets = arrays.Zip(targets, Tuple.Create);
            foreach (var tuple in arraysAndTargets)
            {
                Console.Write("Array: ");
                Print(tuple.array);

                objectTree = new();
                // objectTree.Operation = (Node<Object>? n) => { Console.Write($"[{n}] "); };
                Console.WriteLine("Inserting into BinaryTree...");
                objectTree.Insert(tuple.array);
                Console.WriteLine($"Inserted {objectTree.Count} elements into BinaryTree");

                Console.WriteLine("In-order traversal: ");
                objectTree.InOrderTraversal();
                Console.WriteLine();

                Console.WriteLine("Preorder traversal: ");
                objectTree.PreOrderTraversal();
                Console.WriteLine();

                Console.WriteLine("Postorder traversal: ");
                objectTree.PostOrderTraversal();
                Console.WriteLine();

                Console.WriteLine($"Searching for {tuple.target}...");
                Node<Object>? subtree = objectTree.Search(tuple.target);
                if (subtree != null)
                {
                    Console.WriteLine("Found!");
                    Console.WriteLine("In-order traversal: ");
                    BinaryTree<Object>.InOrderTraversal(subtree, objectTree.Operation);
                    Console.WriteLine();

                    Console.WriteLine("Preorder traversal: ");
                    BinaryTree<Object>.PreOrderTraversal(subtree, objectTree.Operation);
                    Console.WriteLine();

                    Console.WriteLine("Postorder traversal: ");
                    BinaryTree<Object>.PostOrderTraversal(subtree, objectTree.Operation);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{tuple.target} not found.");
                }
                Console.WriteLine();
            }
        }

        static void Print(Object[] array)
        {
            Console.Write("[ ");
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("]");
        }
    }
}
