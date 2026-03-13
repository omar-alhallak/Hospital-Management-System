using System;

namespace Hospital_Management_System.DataStructures
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
    }
}