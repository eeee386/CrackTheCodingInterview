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