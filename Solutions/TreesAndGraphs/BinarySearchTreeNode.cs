using System;

namespace Solutions.TreesAndGraphs
{
    public class BinarySearchTreeNode : BinaryTreeNode<int>
    {
        public BinarySearchTreeNode Left;
        public BinarySearchTreeNode Right;

        public BinarySearchTreeNode(int data) : base(data)
        {
            
        }

        public static BinarySearchTreeNode CreateFromArray(int[] datas)
        {
            // used bigger when having an even, it would cause to be missing one from right
            // and not add it to the left;
            int middleIndex = datas.Length % 2 == 0 ? datas.Length / 2 : (datas.Length - 1) / 2;
            int middleValue = datas[datas.Length / 2 - 1];
            BinarySearchTreeNode node = new BinarySearchTreeNode(datas[middleIndex]);
            for (int i = 1; i < datas.Length; i++)
            {
                if(datas[i] != node.data)
                {
                    node.AddElement(datas[1]);
                }
            }
            return node;
        }

        public void AddElement(int dataToAdd)
        {
            if (dataToAdd <= data)
            {
                if (Left != null)
                {
                    Left.AddElement(dataToAdd); 
                }
                else
                {
                    Left = new BinarySearchTreeNode(dataToAdd);
                }
                
            }
            else
            {
                if (Right != null)
                {
                    Right.AddElement(dataToAdd);
                }
                else
                {
                    Right = new BinarySearchTreeNode(dataToAdd);
                }
            }
        }

        public BinarySearchTreeNode FindElement(int dataToFind)
        {
            if (data == dataToFind)
            {
                return this;
            }

            if (dataToFind < data)
            {
                if (Left == null)
                {
                    throw new Exception("No such element is found.");
                }
                return Left.FindElement(dataToFind);
            }

            if (dataToFind > data)
            {
                if (Right == null)
                {
                    throw new Exception("No such Element is found.");
                }
                return Right.FindElement(dataToFind);
            }
            // I think this is not needed, but compiler was whining.
            throw new Exception("No such element is found.");
        }
    }
}