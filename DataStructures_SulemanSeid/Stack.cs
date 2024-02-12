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

