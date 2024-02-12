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

