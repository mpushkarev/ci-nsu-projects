/******************************************************************************\
*                                                                              *
*  Author:     Mikhail Pushkarev (CI NSU)                                      *
*  Created:    Approx. September - December 2023                               *
*                                                                              *
*  Description:                                                                *
*    Outputs a single row of Pascal’s Triangle based                           *
*    on the user’s input. Primarily written for practicing loops,              *
*    numeric logic, and input/output. Utility is minimal; serves               *
*    as an exercise in basic algorithmic thinking.                             *
*    This was one of the very first projects written during the                *
*    initial stages of learning C#. May contain naive logic or                 *
*    areas for improvement.                                                    *
*                                                                              *
\******************************************************************************/

namespace PascalsTriangle {
    internal class Program {
        static void Main() {

            int neededLine = int.Parse(Console.ReadLine());
            int neededLines = neededLine + 1;

            int[][] triangle = new int[neededLines][];

            for (int line = 0; line < neededLines; line++) {
                triangle[line] = new int[line + 1];
                triangle[line][0] = 1;
                triangle[line][line] = 1;
            }

            for (int line = 2; line < neededLines; line++) {
                for (int cursor = 1; cursor < line; cursor++) {
                    triangle[line][cursor] = triangle[line - 1][cursor - 1] + triangle[line - 1][cursor];
                }
            }

            for (int cursor = 0; cursor <= neededLine; cursor++) {
                Console.Write($" {triangle[neededLine][cursor]} ");
            }
        }
    }
}
