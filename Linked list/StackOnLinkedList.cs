using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOnLinkedList
{
    public class MyList
    {
        public Node Head;

        public class Node
        {
            public int Data;
            public Node Next;
        }

        public void Push(int num)
        {
            Node newNode = new Node();
            newNode.Data = num;
            newNode.Next = Head;
            Head = newNode;
        }

        public Node Pop()
        {
            Node tempNode = Head;
            Head = Head.Next;
            return tempNode;
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
    }
    class Program
    {
        static void Main(string[] args)
        {
           
            MyList list = new MyList();
            for (int i = 0; i < 5; i++)
            {
                list.Push(i);
            }
           
           
            list.printList();
            list.Pop();
            list.printList();

            list.Pop();
            list.Pop();

            list.printList();
            list.Push(10);

            list.printList();
            Console.ReadLine();

        }
    }
}
