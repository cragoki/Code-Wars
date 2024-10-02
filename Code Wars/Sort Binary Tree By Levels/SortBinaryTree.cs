
namespace Code_Wars.Sort_Binary_Tree_By_Levels
{
    public class Node
    {
        public Node Left;
        public Node Right;
        public int Value;

        public Node(Node l, Node r, int v)
        {
            Left = l;
            Right = r;
            Value = v;
        }
    }

    public class SortBinaryTree
    {
        //"Breadth-first traversal"
        //Navigate each level, left to right.
        public static List<int> TreeByLevels(Node node)
        {
            var result = new List<int>();

            if (node == null)
            {
                return result;
            }

            try
            {
                var queue = new Queue<Node>(); //First time I've come across a 'Queue' in .net
                queue.Enqueue(node); // puts the node into the queue

                while (queue.Count > 0)
                {
                    var current = queue.Dequeue(); // gets the first 'Node' and removes it from the queue

                    result.Add(current.Value);

                    // Add the left node to the queue
                    if (current.Left != null)
                    {
                        queue.Enqueue(current.Left);
                    }

                    // Add the right node to the queue
                    if (current.Right != null)
                    {
                        queue.Enqueue(current.Right);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
