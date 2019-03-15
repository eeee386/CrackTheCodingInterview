namespace Solutions.LinkedLists
{
    public class LinkedListSolutions
    {
        public static LinkedListImplementation RemoveDuplicates(LinkedListImplementation linkedList)
        {

            return linkedList.RemoveDuplicates();
        }

        public static int DeleteFromMiddle(LinkedListImplementation linkedList, int data)
        {
            return linkedList.Delete(data);
        }

        public static LinkedListImplementation Partition(LinkedListImplementation linkedList, int partitionValue)
        {
            return linkedList.Partition(partitionValue);
        }

        public static int SumListsReverseOrder(LinkedListImplementation l1, LinkedListImplementation l2)
        {
            return LinkedListImplementation.SumListsReverseOrder(l1, l2);
        }
        
        
        public static int SumListsForwardOrder(LinkedListImplementation l1, LinkedListImplementation l2)
        {
            return LinkedListImplementation.SumListsForwardOrder(l1, l2);
        }

        public static int GetMinValueOfQueue(StacksAndQueues.MyQueue<int> q)
        {
            return q.GetMin();
        }
    }
}