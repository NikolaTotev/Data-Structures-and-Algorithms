using System;
using System.Collections.Generic;
using System.Globalization;

namespace CustomStructures
{
    public class SinglyLinkedList<T> where T : IComparable
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
            if (pos > Size)
            {
                return;
            }

            SinglyLinkedListNode<T> previous = Head;
            SinglyLinkedListNode<T> current = Head;
            SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(data);

            for (int i = 0; i < pos; i++)
            {
                previous = current;
                current = current.Next;
            }

            previous.Next = newNode;
            newNode.Next = current;
            Size++;

        }
        public void InsertAtEnd(T data)
        {
            SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(data);
            SinglyLinkedListNode<T> prevTail = Tail;
            if (Size != 0)
            {
                prevTail.Next = newNode;
                Tail = newNode;
                Size++;
                return;
            }
            Head = newNode;
            Tail = Head;
            Size++;
        }

        public void DeleteStart()
        {
            if (Head != null)
            {
                if (Head.Next != null)
                {
                    Head = Head.Next;
                    Size--;
                    return;
                }

                Head = null;
                Tail = null;
                Size = 0;
            }
        }

        public void DeleteAtPosition(int position)
        {
            if (position > Size)
            {
                return;
            }

            if (position == Size - 1)
            {
                DeleteAtEnd();
                return;
            }

            SinglyLinkedListNode<T> previous = Head;
            SinglyLinkedListNode<T> current = Head;

            for (int i = 0; i < position; i++)
            {
                previous = current;
                current = current.Next;
            }

            previous.Next = current.Next;
            Size--;
        }

        public void DeleteElement(T data)
        {
            if (data.Equals(Tail.Data))
            {
                DeleteAtEnd();
            }

            if (data.Equals(Head.Data))
            {
                DeleteStart();
            }

            SinglyLinkedListNode<T> previous = Head;
            SinglyLinkedListNode<T> current = Head;

            while (current.Next != null)
            {
                previous = current;
                current = current.Next;
                if (current.Data.Equals(data))
                {
                    previous.Next = current.Next;
                    Size--;
                    return;
                }
            }
        }

        public void DeleteAtEnd()
        {
            if (Size == 1)
            {
                Head = null;
                Tail = null;
                Size = 0;
                return;
            }
            SinglyLinkedListNode<T> previous = Head;
            SinglyLinkedListNode<T> current = Head;

            while (current.Next != null)
            {
                previous = current;
                current = current.Next;
            }

            previous.Next = null;
            Tail = previous;
            Size--;
        }

        public List<T> PrintList()
        {
            List<T> listContents = new List<T>();

            if (Size == 0)
            {
                return listContents;
            }
            
            SinglyLinkedListNode<T> previous = Head;
            SinglyLinkedListNode<T> current = Head;

            while (current.Next != null)
            {
                listContents.Add(current.Data);
                previous = current;
                current = current.Next;
            }
            listContents.Add(current.Data);

            return listContents;
        }
    }
}