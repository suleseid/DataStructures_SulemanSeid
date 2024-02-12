using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_SulemanSeid
{
    public class LinkedList_Singly<T>
    {
        // Nested class to represent individual nodes
        public class LinkedListNode
        {
            public T Value { get; set; }
            public LinkedListNode Next { get; set; }

            public LinkedListNode(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private LinkedListNode head;
        private int count;

        // Public property to access the number of elements in the list
        public int Count => count;

        // Constructor to initialize head to null and count to zero
        public LinkedList_Singly()
        {
            head = null;
            count = 0;
        }

        // Core Method: Add an element to the end of the linked list
        public void Add(T value)
        {
            LinkedListNode newNode = new LinkedListNode(value);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                LinkedListNode current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }

            count++;
        }

        // Core Method: Display all elements in the linked list
        public void Display()
        {
            LinkedListNode current = head;
            while (current != null)
            {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        // Core Method: Remove elements by their values
        public void Remove(T value)
        {
            if (head == null)
            {
                return; // Empty list, nothing to remove
            }

            if (head.Value.Equals(value))
            {
                head = head.Next;
                count--;
                return;
            }

            LinkedListNode current = head;
            while (current.Next != null && !current.Next.Value.Equals(value))
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
                count--;
            }
        }

        // Indexer override to access elements by index
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }

                LinkedListNode current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                return current.Value;
            }
        }

        // Additional Methods for inserting elements

        public void InsertAtIndex(int index, T value)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                InsertAtFront(value);
                return;
            }

            LinkedListNode newNode = new LinkedListNode(value);
            LinkedListNode current = head;

            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;

            count++;
        }

        public void InsertAtFront(T value)
        {
            LinkedListNode newNode = new LinkedListNode(value);
            newNode.Next = head;
            head = newNode;
            count++;
        }

        public void InsertAtEnd(T value)
        {
            Add(value); // This method is essentially the same as Add for a singly linked list.
        }

        // Additional Methods for removing elements

        public void RemoveAtIndex(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                RemoveAtFront();
                return;
            }

            LinkedListNode current = head;

            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            current.Next = current.Next?.Next;
            count--;
        }

        public void RemoveAtFront()
        {
            if (head != null)
            {
                head = head.Next;
                count--;
            }
        }

        public void RemoveAtEnd()
        {
            if (head == null || head.Next == null)
            {
                head = null;
            }
            else
            {
                LinkedListNode current = head;

                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                
                current.Next = null;
            }

            count--;
        }

        // Method to clear the linked list
        public void Clear()
        {
            head = null;
            count = 0;
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_SulemanSeid
{
    public class LinkedList_Doubly<T>
    {

        // A node class for a doubly linked list
        public class Node<T>
        {
            public T Data { get; set; } // The data stored in the node
            public Node<T> Prev { get; set; } // The reference to the previous node
            public Node<T> Next { get; set; } // The reference to the next node

            // Constructor to create a new node with data
            public Node(T data)
            {
                Data = data;
                Prev = null;
                Next = null;
            }
        }

        // A class for a doubly linked list
       
            public Node<T> Head { get; private set; } // The head of the list
            public Node<T> Tail { get; private set; } // The tail of the list
            public int Count { get; private set; } // The number of nodes in the   list

            // Constructor to create an empty list
            public LinkedList_Doubly()
            {
                Head = null;
                Tail = null;
                Count = 0;
            }

            // Method to add a new node at the beginning of the list
            public void AddFirst(T data)
            {
                Node<T> newNode = new Node<T>(data); // Create a new node with data
                if (Head == null) // If the list is empty
                {
                    Head = newNode; // Make the new node the head
                    Tail = newNode; // Make the new node the tail
                }
                else // If the list is not empty
                {
                    newNode.Next = Head; // Link the new node to the head
                    Head.Prev = newNode; // Link the head to the new node
                    Head = newNode; // Make the new node the head
                }
                Count++; // Increment the count
            }

            // Method to add a new node at the end of the list
            public void AddLast(T data)
            {
                Node<T> newNode = new Node<T>(data); // Create a new node with data
                if (Head == null) // If the list is empty
                {
                    Head = newNode; // Make the new node the head
                    Tail = newNode; // Make the new node the tail
                }
                else // If the list is not empty
                {
                    newNode.Prev = Tail; // Link the new node to the tail
                    Tail.Next = newNode; // Link the tail to the new node
                    Tail = newNode; // Make the new node the tail
                }
                Count++; // Increment the count
            }

            // Method to remove the first node of the list
            public void RemoveFirst()
            {
                if (Head == null) // If the list is empty
                {
                    throw new InvalidOperationException("The list is empty");
                }
                else // If the list is not empty
                {
                    if (Head.Next == null) // If the list has only one node
                    {
                        Head = null; // Make the head null
                        Tail = null; // Make the tail null
                    }
                    else // If the list has more than one node
                    {
                        Head = Head.Next; // Make the head point to the next node
                        Head.Prev = null; // Make the new head's prev null
                    }
                    Count--; // Decrement the count
                }
            }

            // Method to remove the last node of the list
            public void RemoveLast()
            {
                if (Head == null) // If the list is empty
                {
                    throw new InvalidOperationException("The list is empty");
                }
                else // If the list is not empty
                {
                    if (Head.Next == null) // If the list has only one node
                    {
                        Head = null; // Make the head null
                        Tail = null; // Make the tail null
                    }
                    else // If the list has more than one node
                    {
                        Tail = Tail.Prev; // Make the tail point to the previous node
                        Tail.Next = null; // Make the new tail's next null
                    }
                    Count--; // Decrement the count
                }
            }

            // Method to check if the list contains a given data
            public bool Contains(T data)
            {
                Node<T> current = Head; // Start from the head
                while (current != null) // Traverse the list until the end
                {
                    if (current.Data.Equals(data)) // If the current node's data matches the given data
                    {
                        return true; // Return true
                    }
                    current = current.Next; // Move to the next node
                }
                return false; // Return false if no match is found
            }

            // Method to print the list from head to tail
            public void PrintForward()
            {
                Node<T> current = Head; // Start from the head
                while (current != null) // Traverse the list until the end
                {
                    Console.Write(current.Data + " "); // Print the data
                    current = current.Next; // Move to the next node
                }
                Console.WriteLine(); // Print a new line
            }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataStructures_SulemanSeid
{
        // A class for a queue
        public class Queue<T>
        {
            private LinkedList<T> list; // A linked list to store the elements

            // Constructor to create an empty queue
            public Queue()
            {
                list = new LinkedList<T>();
            }

            // Method to add an element at the end of the queue
            public void Enqueue(T item)
            {
                list.AddLast(item);
            }

            // Method to remove and return an element from the front of the queue
            public T Dequeue()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("The queue is empty");
                }
                else
                {
                    T item = list.First.Value; // Get the first element
                    list.RemoveFirst(); // Remove the first element
                    return item; // Return the element
                }
            }

            // Method to return an element from the front of the queue without removing it
            public T Peek()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("The queue is empty");
                }
                else
                {
                    return list.First.Value; // Return the first element
                }
            }

            // Method to check if the queue is empty
            public bool IsEmpty()
            {
                return list.Count == 0;
            }

            // Method to get the size of the queue
            public int Size()
            {
                return list.Count;
            }

            // Method to print the queue
            public void Print()
            {
                foreach (T item in list)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }

        }

 }
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_SulemanSeid
{
    // A class for a stack
    public class Stack<T>
    {
        private LinkedList<T> list; // A linked list to store the elements

        // Constructor to create an empty stack
        public Stack()
        {
            list = new LinkedList<T>();
        }

        // Method to add an element at the top of the stack
        public void Push(T item)
        {
            list.AddFirst(item);
        }

        // Method to remove and return an element from the top of the stack
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty");
            }
            else
            {
                T item = list.First.Value; // Get the first element
                list.RemoveFirst(); // Remove the first element
                return item; // Return the element
            }
        }

        // Method to return an element from the top of the stack without removing it
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty");
            }
            else
            {
                return list.First.Value; // Return the first element
            }
        }

        // Method to check if the stack is empty
        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        // Method to get the size of the stack
        public int Size()
        {
            return list.Count;
        }

        // Method to print the stack
        public void Print()
        {
            foreach (T item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

        }
    }
}

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
