/******************************************************************************\
*                                                                              *
*  Author:     Mikhail Pushkarev (CI NSU)                                      *
*  Created:    Approx. September - December 2023                               *
*                                                                              *
*  Description:                                                                *
*    Basic implementation of the Sieve of Eratosthenes algorithm               *
*    to find prime numbers up to a given limit.                                *
*    This was one of the very first projects written during the                *
*    initial stages of learning C#. May contain naive logic or                 *
*    areas for improvement.                                                    *
*                                                                              *
\******************************************************************************/

namespace SieveOfEratosthenes {
    internal class Program {
        static void Main() {

            int maxNum = int.Parse(Console.ReadLine());

            int[] numsList = new int[maxNum - 1];

            for (int num = 2; num <= maxNum; num++) {
                numsList[num - 2] = num;
            }

            for (int numId = 0; numId < numsList.Length; numId++) {
                if (numsList[numId] != -1) {
                    for (int num = numsList[numId] * 2; num - 2 < numsList.Length; num += numsList[numId]) {
                        numsList[num - 2] = -1;
                    }
                }
            }

            for (int numId = 0; numId < numsList.Length; numId++) {
                if (numsList[numId] != -1) {
                    Console.Write($"{numsList[numId]} ");
                }
            }
        }
    }
}
