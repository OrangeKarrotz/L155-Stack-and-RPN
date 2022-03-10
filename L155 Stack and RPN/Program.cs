using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L155_Stack_and_RPN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack myStack = new Stack(5);
            ConsoleKey input;
            do
            {
                Console.Clear();
                Console.WriteLine(@"	1. Peek - Return the top item without removing it
	2. Pop - Remove and return the top item
	3. Push - Add a new item to the top
	4. IsEmpty - Check if the stack is empty
        5. IsFull - Check if the stack is full
        [esc] - Exit
        Debugging:
        6. Count - num of elements in stack
        Options:
        7. RPN Evaluator - evaluates RPN input");
                input = Console.ReadKey().Key;
                Console.WriteLine();
                switch (input)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine(myStack.Peek());
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine(myStack.Pop());
                        break;
                    case ConsoleKey.D3:
                        int pushing;
                        do
                        {
                            Console.Write("Enter a value to push: ");
                        } while (!int.TryParse(Console.ReadLine(), out pushing));
                        myStack.Push(pushing);
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine(myStack.IsEmpty());
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine(myStack.IsFull());
                        break;
                    case ConsoleKey.D6:
                        Console.WriteLine(myStack.Count());
                        break;
                    case ConsoleKey.D7:
                        Evaluate();
                        break;
                    default:
                        Console.WriteLine("Please provide a valid input");
                        break;
                }
                Console.WriteLine("\n\n");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            } while (input != ConsoleKey.Escape);
        }
        static void Evaluate()
        {
            
            Console.WriteLine("Enter your RPN input");
            string rpn = Console.ReadLine();
            Stack myStack = new Stack(rpn.Length);
            for (int i = 0; i < rpn.Length; i++)
            {
                if (rpn[i] == '/' || rpn[i] == '*' || rpn[i] == '+' || rpn[i] == '-')
                {
                    Operate((char)rpn[i], ref myStack);
                }
                else
                {
                    int a;
                    int.TryParse(rpn[i].ToString(), out a);
                    myStack.Push(a);
                }
            }
            int b = myStack.Pop();
            if (myStack.IsEmpty())
            {
                Console.WriteLine("Result: " + b);
            }
            else
            {
                Console.WriteLine("The stack is not empty and there are no operands left.");
                Console.WriteLine("Current contents:");
                List<int> contents = new List<int> { b };
                while (!myStack.IsEmpty())
                {
                    contents.Add(myStack.Pop());
                }
                contents.Reverse();
                for (int i = 0; i < contents.Count; i++)
                {
                    Console.WriteLine(contents[i]);
                }
            }
        }
        static void Operate(char operand, ref Stack myStack)
        {
            if (operand == '+')
            {
                int temp = myStack.Pop();
                myStack.Push(myStack.Pop() + temp);
            }
            if (operand == '-')
            {
                int temp = myStack.Pop();
                myStack.Push(myStack.Pop() - temp);
            }
            if (operand == '*')
            {
                int temp = myStack.Pop();
                myStack.Push(myStack.Pop() * temp);
            }
            if (operand == '/')
            {
                int temp = myStack.Pop();
                myStack.Push(myStack.Pop() / temp);
            }
        }
    }
}
