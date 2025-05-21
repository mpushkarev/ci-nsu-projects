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
    internal class Program {
        static void Main() {
            
            MyStack ms1 = new MyStack(3);
            ms1.Push(1);
            ms1.Push(2);
            ms1.Push(3);
            ms1.Print();

            MyStack ms2 = new MyStack(ms1);
            ms2.Pop();
            ms2.Print();
        }
    }
}
