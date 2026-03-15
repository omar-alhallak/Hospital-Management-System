using System;

namespace Hospital_Management_System.Infrastructure.DataStructures
{
    public class Node<T>
    {
        private T data;
        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        private Node<T> next;
        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        public Node()
        {
            next = null;
        }

        public Node(T data)
        {
            this.data = data;
            next = null;
        }

        ~Node() { }
    }
}