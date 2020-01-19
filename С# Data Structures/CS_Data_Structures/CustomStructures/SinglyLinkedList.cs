namespace CustomStructures
{
    public class SinglyLinkedList<T>
    {
        public SinglyLinkedListNode<T> Head { get; set; }
        public SinglyLinkedListNode<T> Tail { get; set; }
        public int Size { get; set; }

        public SinglyLinkedList()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }

        public SinglyLinkedList(T headData)
        {
            Head = new SinglyLinkedListNode<T>(headData);
            Tail = Head;
            Size = 1;
        }

        public void InsertAtStart(T data)
        {
            SinglyLinkedListNode<T> newHead = new SinglyLinkedListNode<T>(data);
            if (Head != null)
            {
                newHead.Next = Head;
                Head = newHead;
                Size++;
                return;
            }

            Head = newHead;
            Tail = Head;
            Size++;
        }
        public void InsertAtPosition(int pos, T data)
        {

        }
        public void InsertAtEnd(T data)
        {
            SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(data);
            if (Size != 0)
            {
                Tail.Next = newNode;
                Size++;
                return;
            }
            Head = newNode;
            Tail = Head;
            Size++;
        }


    }
}