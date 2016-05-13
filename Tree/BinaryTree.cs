
namespace BinaryTree
{
    public class Node
    {
        private Node left;
        private Node right;
        private int value;

        public Node(Node left, Node right, int value)
        {
            this.left = left;
            this.right = right;
            this.value = value;
        }

        public Node getLeft()
        {
            return left;
        }

        public Node getRight()
        {
            return right;
        }

        public int getValue()
        {
            return value;
        }

        //find O(log(n))
        public Node findNode(Node root, int value)
        {
            while (root != null)
            {
                int currval = root.getValue();
                if(currval == value) break;
                if (currval < value)
                {
                    root = root.getRight();
                }
                else
                {
                    //currval > value
                    root = root.getLeft();
                }
            }
            return root;
        }

        // tree Height O(n)
        public static int treeHeight(Node n)
        {
            if(n == null) return 0;
            return 1 + Math.max( treeHeight( n.getLeft()), treeHeight(n.getRight()));
        }

    }
    
}
