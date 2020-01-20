using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStructures
{
    class MultiGraphNode
    {
        public int Data { get; set; }
        public bool IsVisited { get; set; }
        public int ComponentIndex { get; set; }
        public List<Edge<MultiGraphNode>> Connections { get; set; }
        public MultiGraphNode(int data)
        {
            Data = data;
            Connections = new List<Edge<MultiGraphNode>>();
        }
    }
}
