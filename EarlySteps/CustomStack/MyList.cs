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
    internal class MyList {
        public Node? Head { get; set; }
        public Node? Tail { get; set; }
    }
}
