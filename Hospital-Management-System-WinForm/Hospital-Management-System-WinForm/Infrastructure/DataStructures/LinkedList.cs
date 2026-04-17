namespace Hospital_Management_System_WinForm.Infrastructure.DataStructures
{
    public class LinkedList<T>
    {
        private Node<T>? head;

        public Node<T>? Head => head;

        public LinkedList() => head = null;

        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node<T> current = head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }
    }
}