using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListWithReverse
{
    public class MyList
    {
        public Node Head;

        public class Node
        {
            public int Data;
            public Node Next;
        }

        public void Add(int num)
        {
            Node newNode = new Node();
            newNode.Data = num;
            if (Head != null)
            {
                Node helpNode = Head;
                while (helpNode.Next != null)
                    helpNode = helpNode.Next;
                helpNode.Next = newNode;
            }
            else
            {
                Head = newNode;
            }
        }

        public void printList()
        {
            Node helpNode = Head;
            while (helpNode != null)
            {
                Console.WriteLine(helpNode.Data);
                helpNode = helpNode.Next;
            }
        }

        public void Reverse()
        {
            Node helpNode = new Node();
            Node newHead = null;

            while ((helpNode = Head) != null)
            {
                Head = Head.Next;
                helpNode.Next = newHead;
                newHead = helpNode;
            }
            Head = newHead;
        }

        public MyList()
        {
            for (int i = 0; i < 5; i++)
            {
                Add(i);
            }
        } 

    }
    class Program
    {
        static void Main(string[] args)
        {
           
            MyList list = new MyList();
            list.printList();
            list.Reverse();
            list.printList();
            Console.ReadLine();

        }
    }
}
