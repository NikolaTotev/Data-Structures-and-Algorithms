using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStructures
{
    public static class MST_Algorithms
    {
        public static void Kruskal(ref WeightedUndirectedGraph<T> graph) 
        {
            DisjointSet<T>set = new DisjointSet<T>();
            foreach (var nodesKey in graph.Nodes.Keys)
            {
                set.MakeSet(nodesKey);
            }

            List<Edge<T>> sortedEdges = new List<Edge<T>>();
         
            sortedEdges = graph.Edges.OrderBy(if(x is WeightedUndirectedGraphNode<T, int> node) => node.Weight).ToList<T>();

            foreach (var edge in sortedEdges)
            {
                if (set.FindSet(edge.Node1) != set.FindSet(edge.Node2))
                {
                    edge.PrintEdge();
                    set.Union(edge.Node1, edge.Node2);
                }
            }
        }

        public static void Prim(WeightedUndirectedGraph<string> graph)
        {
            Dictionary<string, WeightedUndirectedGraphNode<string, int>> nodes = graph.Nodes;
            Dictionary<string, bool> selected = new Dictionary<string, bool>();

            foreach (var nodesKey in nodes.Keys)
            {
                selected.Add(nodesKey, false);
            }


            selected[selected.Keys.ToList()[0]] = true;

            string node1 = "";
            string node2 = "";
            int weight = 0;
            int edgeNumber = 0;
            while (edgeNumber < nodes.Count - 1)
            {
                int min = Int32.MaxValue;

                foreach (var key in nodes.Keys)
                {
                    if (selected[key])
                    {
                        foreach (var connection in nodes[key].GetNeighbors())
                        {
                            if (!selected[connection.Key])
                            {
                                if (connection.Value.ConnectionWeight < min)
                                {
                                    min = connection.Value.ConnectionWeight;
                                    node1 = key;
                                    node2 = connection.Key;
                                    weight = connection.Value.ConnectionWeight;
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("{0} : {1} - {2}", node1, node2, weight.ToString());
                selected[node2] = true;
                edgeNumber++;
            }

        }
    }
}
