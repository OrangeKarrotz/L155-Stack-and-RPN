using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L155_Stack_and_RPN
{
    internal class Stack
    {
        private List<int> stack; private int maxsize;

        public Stack(int initialSize = 0)
        {
            stack = new List<int>();
            maxsize = initialSize;
            //Random rand = new Random();
            //for (int i = 0; i < maxsize; i++)
            //{
            //    stack.Add(rand.Next(0, 100));
            //}
        }
        public int Count()
        {
            return stack.Count;
        }

        public bool Peek(ref int num)
        {
            if (!IsEmpty())
            {
                num = stack[stack.Count - 1];
                return true;
            }
            else return false;
        }
        public int Peek()
        {
            if (!IsEmpty())
            {
                int num = stack[stack.Count - 1];
                return num;
            }
            else
            {
                return 0;
            }
        }
        public bool Pop(ref int num)
        {
            if (!IsEmpty())
            {
                int temp = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                num = temp;
                return true;
            }
            else return false;
        }
        public int Pop()
        {
            if (!IsEmpty())
            {
                int temp = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                return temp;
            }
            else
            {
                return 0;
            }
        }
        public void Push(int num)
        {
            if (!IsFull())
            {
                stack.Add(num);
                Console.WriteLine("Added " + num + " to the stack");
            }
            else
            {
                Console.WriteLine($"Failed to add {num} to the stack");
            }
        }
        public bool IsEmpty()
        {
            if (stack.Count == 0)
            {
                Console.WriteLine("Error: IsEmpty");
                return true;
            }
            return false;
        }
        public bool IsFull()
        {
            if (stack.Count == maxsize)
            {
                Console.WriteLine("Error: IsFull");
                return true;
            }
            return false;
        }
    }
}
