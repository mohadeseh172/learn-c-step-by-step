using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueAndStack
{
    // Implementation of Stack
    public class Stack<T>
    {
        private T[] _elements;
        private int _size;
        private int _capacity;

        public Stack(int capacity = 10)
        {
            _capacity = capacity;
            _elements = new T[_capacity];
            _size = 0;
        }

        public void Push(T item)
        {
            if (_size == _capacity)
            {
                Resize();
            }
            _elements[_size++] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            T item = _elements[--_size];
            _elements[_size] = default;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return _elements[_size - 1];
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        private void Resize()
        {
            _capacity *= 2;
            T[] newArray = new T[_capacity];
            Array.Copy(_elements, newArray, _size);
            _elements = newArray;
        }
    }

    // Implementation of Queue
    public class Queue<T>
    {
        private T[] _elements;
        private int _head;
        private int _tail;
        private int _size;
        private int _capacity;

        public Queue(int capacity = 10)
        {
            _capacity = capacity;
            _elements = new T[_capacity];
            _head = 0;
            _tail = 0;
            _size = 0;
        }

        public void Enqueue(T item)
        {
            if (_size == _capacity)
            {
                Resize();
            }
            _elements[_tail] = item;
            _tail = (_tail + 1) % _capacity;
            _size++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            T item = _elements[_head];
            _elements[_head] = default;
            _head = (_head + 1) % _capacity;
            _size--;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            return _elements[_head];
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        private void Resize()
        {
            T[] newArray = new T[_capacity * 2];
            for (int i = 0; i < _size; i++)
            {
                newArray[i] = _elements[(_head + i) % _capacity];
            }
            _head = 0;
            _tail = _size;
            _capacity *= 2;
            _elements = newArray;
        }
    }

    // Test Program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stack Demo:");
            Stack<int> stack = new Stack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Console.WriteLine("Top of Stack: " + stack.Peek());
            Console.WriteLine("Popped: " + stack.Pop());
            Console.WriteLine("Top of Stack after Pop: " + stack.Peek());

            Console.WriteLine("\nQueue Demo:");
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("Alice");
            queue.Enqueue("Bob");
            queue.Enqueue("Charlie");

            Console.WriteLine("Front of Queue: " + queue.Peek());
            Console.WriteLine("Dequeued: " + queue.Dequeue());
            Console.WriteLine("Front of Queue after Dequeue: " + queue.Peek());
        }
    }
}
