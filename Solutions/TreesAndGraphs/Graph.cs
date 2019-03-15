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
        public Node<T>[] Nodes;

        public class Node<T>
        {
            public readonly T data;
            public HashSet<Node<T>> Nodes;
            public bool visited;

            public Node(T data)
            {
                this.data = data;
            }

            public Node<T> DepthFirstSearch(T dataToSearch)
            {
                if (data.Equals(dataToSearch))git
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
                
            }
        }
    }
}