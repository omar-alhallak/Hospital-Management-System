using System;

namespace Hospital_Management_System.Infrastructure.DataStructures
{ 
    public class LinkedList<T>
    {
        private Node<T> head;
        public Node<T> Head
        {
            get { return head; }
            set { head = value; }
        }

        public LinkedList()
        {
            head = null;
        }

        ~LinkedList() { }

        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (Head == null)
            {
                Head = newNode;
                return;
            }

            Node<T> current = Head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }
    }
}