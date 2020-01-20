using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStructures
{
    class WeightedMultiGraph
    {
        public Dictionary<int, MultiGraphNode> Nodes = new Dictionary<int, MultiGraphNode>();
        public List<Edge<MultiGraphNode>> Edges { get; set; }

        public int NumberOfComponents { get; set; }
        public int MSFWeight { get; set; }

        public WeightedMultiGraph()
        {
            NumberOfComponents = 0;
        }
        public void AddEdge(int vertex1, int vertex2, int edgeWeight)
        {

            MultiGraphNode node1 = new MultiGraphNode(vertex1);
            MultiGraphNode node2 = new MultiGraphNode(vertex2);
            Edge<MultiGraphNode> newEdge = new Edge<MultiGraphNode>(node1, node2, edgeWeight);
            if (!Nodes.ContainsKey(vertex1))
            {
                Nodes.Add(vertex1, new MultiGraphNode(vertex1));
            }

            if (!Nodes.ContainsKey(vertex2))
            {
                Nodes.Add(vertex2, new MultiGraphNode(vertex2));
            }

            Nodes[vertex1].Connections.Add(newEdge);
            Nodes[vertex2].Connections.Add(newEdge);
            Edges.Add(newEdge);
        }

        /// <summary>
        /// Generic BFS function. Can be used to solve any problem that requires BFS, just plug in the inspectionFunc.
        /// </summary>
        /// <param name="inspectFunc">Must return true if the search is completed and no more nodes need to be checked</param>
        /// <param name="startId">Starting node, by default it is 0.</param>

        public void SetComponenets(bool countComponents)
        {
            if (Nodes.Count == 0)
            {
                return;
            }

            Queue<MultiGraphNode> nodeQueue = new Queue<MultiGraphNode>();
            foreach (var node in Nodes)
            {

                if (!node.Value.IsVisited)
                {
                    if (countComponents)
                    {
                        NumberOfComponents++;
                    }
                    nodeQueue.Enqueue(node.Value);
                    node.Value.IsVisited = true;
                    node.Value.ComponentIndex = NumberOfComponents;

                    while (nodeQueue.Count != 0)
                    {
                        MultiGraphNode currentNode = nodeQueue.Dequeue();

                        foreach (var connection in currentNode.Connections)
                        {
                            if (!connection.Node2.IsVisited)
                            {
                                connection.Node2.IsVisited = true;
                                connection.Node2.ComponentIndex = NumberOfComponents;
                                nodeQueue.Enqueue(connection.Node1);
                            }
                        }

                    }
                }
            }
        }

        public void Kruskal()
        {
            for (int i = 0; i < NumberOfComponents; i++)
            {

                DisjointSet set = new DisjointSet();
                foreach (var nodesKey in Nodes.Keys)
                {
                    if (Nodes[nodesKey].ComponentIndex == i)
                    {
                        set.MakeSet(Nodes[nodesKey]);
                    }
                    
                }

                List<Edge<MultiGraphNode>> sortedEdges = Edges.OrderBy(x => x.Weight).ToList();

                foreach (var edge in sortedEdges)
                {
                    if (set.FindSet(edge.Node1) != set.FindSet(edge.Node2))
                    {
                        MSFWeight += edge.Weight;
                        set.Union(edge.Node1, edge.Node2);
                    }
                }
            }
        }

        public int CalculateWeight()
        {
            SetComponenets(true);

            return MSFWeight;
        }
    }
}
