namespace Hospital_Management_System_WinForm.Infrastructure.DataStructures
{
    public class Node<T>
    {
        public T Data { get; set; }

        public Node<T>? Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }
}