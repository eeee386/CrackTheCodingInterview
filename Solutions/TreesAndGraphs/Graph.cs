using System;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Solutions.StacksAndQueues;


namespace Solutions.TreesAndGraphs
{
    public class Graph<T>
    {
        public HashSet<Node<T>> Nodes;

        public Graph(HashSet<Node<T>> nodes)
        {
            Nodes = new HashSet<Node<T>>(nodes);
        }

        public class Node<T>
        {
            public readonly T data;
            public HashSet<Node<T>> Nodes;

            // for DFS or BFS
            public bool visited;

            // for bidirectional search
            public bool visited1;
            public bool visited2;

            public Node(T data)
            {
                this.data = data;
            }

            public Node<T> DepthFirstSearch(T dataToSearch)
            {
                if (data.Equals(dataToSearch))
                {
                    return this;
                }

                visited = true;
                if (Nodes.Any(node => node.visited == false))
                {
                    return DepthFirstSearch(dataToSearch);
                }

                throw new Exception("No such element in graph!");
            }

            public Node<T> BreadthFirstSearch(T dataToSearch)
            {
                MyQueue<Node<T>> queue = new MyQueue<Node<T>>();
                visited = true;
                queue.Enqueue(this);
                while (!queue.IsEmpty())
                {
                    Node<T> dequeuedNode = queue.Dequeue();
                    if (dequeuedNode.data.Equals(dataToSearch))
                    {
                        return this;
                    }

                    foreach (var node in dequeuedNode.Nodes)
                    {
                        if (node.visited == false)
                        {
                            node.visited = true;
                            queue.Enqueue(node);
                        }
                    }
                }

                throw new Exception("No such element in graph!");
            }

            public static Node<T> BiDirectionalSearch(Node<T> node1, Node<T> node2)
            {
                MyQueue<Node<T>> myQueue1 = new MyQueue<Node<T>>();
                MyQueue<Node<T>> myQueue2 = new MyQueue<Node<T>>();

                node1.visited1 = true;
                node2.visited2 = true;

                myQueue1.Enqueue(node1);
                myQueue2.Enqueue(node2);

                while (!(myQueue1.IsEmpty() && myQueue2.IsEmpty()))
                {
                    Node<T> dequeuedNode1 = myQueue1.Dequeue();
                    Node<T> dequeuedNode2 = myQueue2.Dequeue();

                    if (dequeuedNode1.visited2)
                    {
                        return dequeuedNode1;
                    }

                    if (dequeuedNode2.visited1)
                    {
                        return dequeuedNode2;
                    }

                    foreach (var childNode1 in dequeuedNode1.Nodes)
                    {
                        if (childNode1.visited1 == false)
                        {
                            childNode1.visited1 = true;
                            myQueue1.Enqueue(childNode1);
                        }
                    }

                    foreach (var childNode2 in dequeuedNode2.Nodes)
                    {
                        if (childNode2.visited1 == false)
                        {
                            childNode2.visited1 = true;
                            myQueue1.Enqueue(childNode2);
                        }
                    }
                }

                throw new Exception("No path found between the nodes");
            }

            public static List<Node<T>> BuildOrder(HashSet<Node<T>> nodes, List<Tuple<Node<T>, Node<T>>> dependencies)
            {
                var dictOfDependencies = new Dictionary<Node<T>, HashSet<Node<T>>>();
                foreach (var node in nodes)
                {
                    dictOfDependencies[node] = new HashSet<Node<T>>();
                }

                foreach (var dependency in dependencies)
                {
                    dictOfDependencies[dependency.Item2].Add(dependency.Item1);
                }

                var sort = from entry in dictOfDependencies orderby entry.Value select entry;
                var sortedDict = sort.ToDictionary(item => item.Key, item => item.Value);
                
                
                List<Node<T>> buildOrder = new List<Node<T>>();
                int prevCount = 0;
                while (buildOrder.Count != dictOfDependencies.Keys.Count || prevCount == buildOrder.Count)
                {
                    prevCount = buildOrder.Count;
                    foreach (var key in sortedDict.Keys)
                    {
                        sortedDict[key] = sortedDict[key].Except(buildOrder).ToHashSet();
                        if (!dictOfDependencies[key].Any())
                        {
                            buildOrder.Add(key);
                        }
                    }
                }

                return buildOrder;
            }
        }
    }
}