using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataStructures_SulemanSeid
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Testing LinkedList
            Console.WriteLine("Testing LinkedList - Singly:");
            LinkedList_Singly<int> SinlinkList = new LinkedList_Singly<int>();
            SinlinkList.Add(1);
            SinlinkList.Add(2);
            SinlinkList.Add(3);

            Console.WriteLine("Original List:");
            SinlinkList.Display(); // Call the custom Display method
                                   // You need to implement this method in your LinkedList class

            // Testing LinkedList - Doubly:
            Console.WriteLine("\nTesting LinkedList - Doubly:");
            LinkedList_Doubly<int> doublyLinkedList = new LinkedList_Doubly<int>();
            doublyLinkedList.AddLast(1);
            doublyLinkedList.AddLast(2);
            doublyLinkedList.AddLast(3);
            doublyLinkedList.PrintForward();
            // You need to implement this method in your LinkedList class

            // Testing Queue
            Console.WriteLine("\nTesting Queue:");
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            // Call other Queue methods as needed
            Console.WriteLine(queue.Peek()); // Output: A
            Console.WriteLine(queue.Dequeue()); // Output: A
            Console.WriteLine(queue.Peek()); // Output: B

            // Testing Stack
            Console.WriteLine("\nTesting Stack:");
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            // Call other Stack methods as needed
            Console.WriteLine(stack.Peek()); 
            Console.WriteLine(stack.Pop()); 
            Console.WriteLine(stack.Peek());
        }
    }
    
}
