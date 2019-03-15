using System;
using System.Collections.Generic;

namespace Solutions.LinkedLists
{
    public class LinkedListImplementation
    {
        private Node _node;

        public LinkedListImplementation(){}
        
        public LinkedListImplementation (LinkedListImplementation linkedList)
        {
            _node = linkedList._node;
        } 
        
        private LinkedListImplementation(Node newNode)
        {
            _node = newNode;
        } 

        public int AddToTail(int data)
        {
            if (_node == null)
            {
                _node = new Node(data);
            }
            else
            {
                _node.AppendToTail(data);
            }
            return data;
        }

        public int Delete(int data)
        {
            if (_node == null)
            {
                throw new Exception("You cannot delete from an empty LinkedList");
            }
            _node = _node.DeleteNode(data);

            return data;
        }

        public int AddToHead(int data)
        {
            if (_node == null)
            {
                _node = new Node(data);
            }
            else
            {
                _node = _node.AppendToHead(data);
            }

            return data;
        }

        public LinkedListImplementation RemoveDuplicates()
        {
            return _node == null ? new LinkedListImplementation() : new LinkedListImplementation(_node.RemoveDuplicates());
        }

        public LinkedListImplementation Partition(int partitionValue)
        {
            Node node = Node.Partition(_node, partitionValue);
            return new LinkedListImplementation(node);
        }

        public static int SumListsReverseOrder(LinkedListImplementation linkedListImplementation1,
            LinkedListImplementation linkedListImplementation2)
        {
            return Node.SumNodesReverseOrder(linkedListImplementation1._node, linkedListImplementation2._node);
        }
        
        public static int SumListsForwardOrder(LinkedListImplementation linkedListImplementation1,
            LinkedListImplementation linkedListImplementation2)
        {
            return Node.SumNodesForwardOrder(linkedListImplementation1._node, linkedListImplementation2._node);
        }

        public int Size()
        {
            return _node?.NumberOfNodes() ?? 0;
        }

        public void WriteToConsole()
        {
            _node?.WriteToConsole();
        }
        
        public class Node
        {
            private Node _next = null;
            private readonly int _data;

            internal Node(int data)
            {
                _data = data;
            }
            
            internal Node(Node node)
            {
                _next = node._next;
                _data = node._data;
            }

            public void AppendToTail(int data)
            {
                Node nodeEnd = new Node(data);
                Node n = this;
                while (n._next != null)
                {
                    n = n._next;
                }
                n._next = nodeEnd;
            }

            public Node AppendToHead(int data)
            {
                Node newHead = new Node(data);
                newHead._next = this;
                return newHead;
            }

            private Node AppendNodeToHead(Node newHead)
            {
                Node n = newHead;
                while (n._next != null)
                {
                    n = n._next;
                }
                n._next = this;
                return newHead;
            }

            private Node AppendNodeToTail(Node newTail)
            {
                Node n = this;
                while (n._next != null)
                {
                    n = n._next;
                }

                n._next = newTail;
                return this;
            }

            public Node DeleteNode(int data)
            {
                Node n = this;

                if (n._data == data)
                {
                    return _next;
                }

                while (n._next != null)
                {
                    if (n._next._data == data)
                    {
                        n._next = n._next._next;
                        return this;
                    }

                    n = n._next;
                }

                return this;
            }

            public Node RemoveDuplicates()
            {
                HashSet<int> hashSet = new HashSet<int>();
                Node n = this;
                Node previous = null;

                while (n != null)
                {
                    if (hashSet.Contains(n._data))
                    {
                        previous._next = n._next;
                    }
                    else
                    {
                        hashSet.Add(n._data);
                        previous = n;
                    }
                    n = n._next;
                }
                return this;
            }

            public Node RemoveDuplicatesWithNoBuffer()
            {
                Node current = this;
                while (current != null)
                {
                    Node runner = current;
                    while (runner._next != null)
                    {
                        if (runner._next._data == current._data)
                        {
                            runner._next = runner._next._next;
                        }
                        else
                        {
                            runner = runner._next;
                        }
                    }
                    current = current._next;
                }

                return this;
            }

            public static Node Partition(Node head, int partitionValue)
            {
                Node newNode = null;
                Node n = head;
                while (n != null)
                {
                    if (n._data >= partitionValue)
                    {
                        if (newNode == null)
                        {
                            newNode = new Node(n._data);
                        }
                        else
                        {
                            newNode.AppendToTail(n._data);
                        }
                    }
                    else
                    {
                        if (newNode == null)
                        {
                            newNode = new Node(n._data);
                        }
                        else
                        {
                            newNode = newNode.AppendToHead(n._data);
                        }
                    }
                    n = n._next;
                }

                return newNode;
            }

            public static int SumNodesReverseOrder(Node node1, Node node2)
            {
                Node n1 = node1;
                Node n2 = node2;
                int counter = 1;
                int sum = 0;
                while (n1 != null)
                {
                    sum += n1._data * counter;
                    counter = counter * 10;
                    n1 = n1._next;
                }

                counter = 1;
                while (n2 != null)
                {
                    sum += n2._data * counter;
                    counter = counter * 10;
                    n2 = n2._next;
                }

                return sum;
            }
            
            public static int SumNodesForwardOrder(Node node1, Node node2)
            {
                Node n1 = node1;
                Node n2 = node2;
                int sum = 0;
                string tempString = "";
                while (n1 != null)
                {
                    tempString = String.Concat(tempString, Convert.ToString(n1._data));
                    n1 = n1._next;
                }

                sum += Convert.ToInt32(tempString);
                tempString = "";
                
                while (n2 != null)
                {
                    tempString = String.Concat(tempString, Convert.ToString(n2._data));
                    n2 = n2._next;
                }
                
                sum += Convert.ToInt32(tempString);

                return sum;
            }

            public bool IsPalindrome()
            {
                int size = NumberOfNodes();
                Node n = this;
                Node runnerNode = this;

                if (size % 2 == 0)
                {
                    for (int i = 0; i < (size % 2 == 0 ? size / 2 + 1 : size / 2 + 2) ; i++)
                    {
                        runnerNode = runnerNode._next;
                    }
                    
                    while (runnerNode != null)
                    {
                        if (runnerNode._data != n._data)
                        {
                            return false;
                        }
                        runnerNode = runnerNode._next;
                        n = n._next;
                    }
                }

                return true;
            }

            public void WriteToConsole()
            {
                Node n = this;
                Console.WriteLine(n._data);
                while (n._next != null)
                {
                    Console.WriteLine(n._next._data);
                    n = n._next;
                }
            }

            public int NumberOfNodes()
            {
                Node n = this;
                int counter = 0;
                while (n != null)
                {
                    counter++;
                    n = n._next;
                }

                return counter;
            }
        }
    }
}