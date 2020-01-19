using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace CustomStructures
{
    public class SinglyLinkedListNode<T> where T:IComparable
    {
        public T Data { get; set; }
        public SinglyLinkedListNode<T> Next { get; set; }

        public SinglyLinkedListNode(T data)
        {
            Data = data;
            Next = null;
        }

        public void AddNext(SinglyLinkedListNode<T> next)
        {
            if (next != this)
            {
                Next = next;
            }
        }
    }
}