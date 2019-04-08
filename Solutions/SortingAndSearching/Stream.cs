using System.Collections.Generic;
using Solutions.TreesAndGraphs;

namespace Solutions.SortingAndSearching
{
    public class NumberStream
    {
        private RankNode root = null;

        public class RankNode
        {
            public int leftSize = 0;
            public RankNode left, right;
            public int data = 0;

            public RankNode(int d)
            {
                data = d;
            }

            public void Insert(int d)
            {
                if (d <= data)
                {
                    if (left != null)
                    {
                        left.Insert(d);
                        leftSize++;
                    }
                    else
                    {
                        left = new RankNode(d);
                    }
                }
                else
                {
                    if (right != null)
                    {
                        right.Insert(d);
                    }
                    else
                    {
                        right = new RankNode(d);
                    }
                }
            }

            public int GetRank(int d)
            {
                if (d == data)
                {
                    return leftSize;
                }

                if (d < data)
                {
                    if (left == null)
                    {
                        return -1;
                    }
                    else
                    {
                        left.GetRank(d);
                    }
                }
                else
                {
                    int rightRank = right?.GetRank(d) ?? -1;
                    if (rightRank == -1)
                    {
                        return -1;
                    }

                    return leftSize + 1 + rightRank;

                }
            }
        }
    }
}