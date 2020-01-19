using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomStructures;
namespace LinkedListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> numberList = new SinglyLinkedList<int>();

            numberList.InsertAtEnd(1);
            numberList.InsertAtEnd(2);
            numberList.InsertAtEnd(3);
            numberList.InsertAtEnd(4);
            Console.WriteLine("Initial values.");
            Print(numberList.PrintList());


            numberList.InsertAtStart(5);
            Console.WriteLine("Insert at start 5.");
            Print(numberList.PrintList());

            numberList.InsertAtPosition(3, 42);
            Console.WriteLine("Insert at position 3, 42.");
            Print(numberList.PrintList());

            numberList.DeleteStart();
            Console.WriteLine("Delete start.");
            Print(numberList.PrintList());

            numberList.DeleteAtEnd();
            Console.WriteLine("Delete end.");
            Print(numberList.PrintList());

            numberList.DeleteAtPosition(3);
            Console.WriteLine("Delete as position 3.");
            Print(numberList.PrintList());

            numberList.DeleteElement(42);
            Console.WriteLine("Delete element 42.");
            Print(numberList.PrintList());

            numberList.DeleteAtEnd();
            Console.WriteLine("Leave one element.");
            Print(numberList.PrintList());

            numberList.DeleteAtEnd();
            Console.WriteLine("Remove all.");
            Print(numberList.PrintList());

            numberList.InsertAtStart(2);
            Console.WriteLine("Insert at start.");
            Print(numberList.PrintList());


        }

        public static void Print(List<int> listToPrint)
        {
            foreach (var i in listToPrint)
            {
                Console.Write("{0} ", i.ToString());
            }

            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
