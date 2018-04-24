using System;
using System.Diagnostics;

namespace CodingGame
{
    class FuiteMemory
    {
        //static void Main(string[] args)
        //{
        //    Stack stack = new Stack(10000);
        //    showMemoryUse();

        //    for (int i = 0; i < 10000; i++)
        //        stack.push("a large large large largefffff string" + i);
        //    for (int i = 0; i < 10000; i++)
        //    {
        //        stack.pop();
        //        //Console.WriteLine(stack.pop());
        //    }
        //    showMemoryUse();
        //    Console.ReadKey();
        //}

        private static void showMemoryUse()
        {
            Process proc = Process.GetCurrentProcess();
            Console.WriteLine(proc.PrivateMemorySize64);
        }
        class Stack
        {
            private Object[] elements;
            private int size = 0;

            public Stack(int initialCapacity)
            {
                elements = new Object[initialCapacity];
            }

            public void push(Object obj)
            {
                ensureCapacity();
                elements[size++] = obj;
            }

            public Object pop()
            {
                if (size == 0)
                    throw new Exception();

                object obj = elements[--size];
                elements[size] = null;
                return obj;
            }

            private void ensureCapacity()
            {
                if (elements.Length == size)
                {
                    Object[] old = elements;
                    elements = new Object[2 * size + 1];
                    Array.Copy(old, 0, elements, 0, size);
                }
            }
        }
    }
}
