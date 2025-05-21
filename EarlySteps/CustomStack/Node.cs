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
    internal class Node {

        public int Data { get; set; }
        public Node? Next { get; set; }

        public Node(int data) {
            Data = data;
        }
    }
}
