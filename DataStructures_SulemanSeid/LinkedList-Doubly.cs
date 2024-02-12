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
