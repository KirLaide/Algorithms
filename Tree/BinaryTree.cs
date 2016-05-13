
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

        //O(n) Traversal with recursion
        public void preorderTraversal(Node root)
        {
            if(root == null) return;
            root.printValue();
            preorderTraversal( root.getLeft());
            preorderTraversal( root,getRight());
        }
        public void inorderTraversal(Node root)
        {
            if(root == null) return;
            preorderTraversal( root.getLeft());
            root.printValue();
            preorderTraversal( root,getRight());
        }
        public void postorderTraversal(Node root)
        {
            if(root == null) return;
            preorderTraversal( root.getLeft());
            preorderTraversal( root,getRight());
            root.printValue();
        }

        //O(n) Traversal with out recursion (with stack)
        public void preorderTraversalWithStack(Node root)
        {
            NodeStack stack = new NodeStack();
            stack.push(root);
            while(stack.size() > 0)
            {
                Node curr = stack.pop();
                curr.printValue();
                Node n = curr.getRight();
                if( n != null ) stack.push(n);
                n = curr.getLeft();
                if( n!= null) stack.push(n)
            }
        }

        //Rotation O(1)
        publci Node rotationRight()
        {
            Node newRoot = left;
            left = newRoot.right;
            newRoot.right = this;
            return newRoot;
        }


    }
    
}
