/******************************************************************************\
*                                                                              *
*  Author:     Mikhail Pushkarev (CI NSU)                                      *
*  Created:    Approx. September - December 2024                               *
*                                                                              *
*  Description:                                                                *
*    Basic implementation of a stack data structure using                      *
*    custom nodes and internal linked list logic.                              *
*    As this was developed at an early stage of learning C#,                   *
*    some parts may be suboptimal or could benefit from further                *
*    refinement.                                                               *
*                                                                              *
\******************************************************************************/

namespace CustomStack {
    internal class MyStack {

        public MyList Storage { get; set; }
        public Node? Head { get; set; }
        public int Count { get; set; }
        public int MaxCount { get; set; }
        public int Sum { get; set; }

        public MyStack(int maxCount) {
            Storage = new MyList();
            Count = 0;
            Sum = 0;
            MaxCount = maxCount;
        }

        public MyStack(MyStack orig) {

            Storage = new MyList();
            Count = orig.Count;
            Sum = orig.Sum;
            MaxCount = orig.MaxCount;

            if (orig.Head == null) {
                Head = null;
            } else {
                Head = new Node(orig.Head.Data);
                Node t = orig.Head.Next;
                Node p = Head;

                while (t != null) {
                    p.Next = new Node(t.Data);
                    p = p.Next;
                    t = t.Next;
                }
            }
        }

        public void Push(int data) {

            if (Count >= MaxCount) {
                Console.WriteLine("Stack overflow!");
            } else {
                Node newNode = new Node(data);
                newNode.Next = Head;
                Head = newNode;
                Storage.Head = Head;
                Count++;
                Sum += data;
            }
        }

        public int Pop() {
            if (Count == 0) {
                Console.WriteLine("Stack underflow!");
                return -1;
            } else {
                int el = Head.Data;
                Node temp = Head;
                Head = Head.Next;
                Storage.Head = Head;
                temp.Next = null;
                Count--;
                Sum -= el;
                return el;
            }
        }

        public int Peek() {
            if (Count == 0) {
                Console.WriteLine("Stack underflow!");
                return -1;
            } else {
                return Head.Data;
            }
        }

        public double Average() {
            if (Count > 0) {
                return (double)Sum / Count;
            } else {
                return 0.0;
            }
        }

        public void Print() {
            Node? temp = Head;
            while (temp != null) {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }
            Console.WriteLine();
        }

        public MyStack Clone() {

            MyStack newStack = new MyStack(MaxCount);

            if (Head == null) {
                return newStack;
            } else {
                MyStack tempStack = new MyStack(Count);
                Node tempNode = Head;

                while (tempNode != null) {
                    tempStack.Push(tempNode.Data);
                    tempNode = tempNode.Next;
                }

                while (tempStack.Count > 0) {
                    newStack.Push(tempStack.Pop());
                }

                return newStack;
            }
        }
    }
}
