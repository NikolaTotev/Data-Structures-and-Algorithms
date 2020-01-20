using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStructures
{
    public class Edge<T>where  T:IComparable
    {
        public T Node1 { get; set; }
        public T Node2 { get; set; }
        public int Weight { get; set; }

        public Edge(T node1, T node2, int weight)
        {
            Node1 = node1;
            Node2 = node2;
            Weight = weight;
        }

        public void PrintEdge()
        {
            Console.WriteLine("{0} : {1} - {2}", Node1, Node2, Weight.ToString());
        }
    }
}
