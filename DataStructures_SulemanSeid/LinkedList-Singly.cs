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

