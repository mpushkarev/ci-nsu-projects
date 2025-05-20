/******************************************************************************\
*                                                                              *
*  Author:     Mikhail Pushkarev (CI NSU)                                      *
*  Created:    Approv. September - December 2023                               *
*                                                                              *
*  Description:                                                                *
*    Simple implementation to search for prime numbers.                        *
*    This was one of the very first projects written during the                *
*    initial stages of learning C#. May contain naive logic or                 *
*    areas for improvement.                                                    *
*                                                                              *
\******************************************************************************/

namespace PrimeSearch {
    internal class Program {
        static void Main() {

            List<int> primesList = new List<int>();

            int target = int.Parse(Console.ReadLine());

            for (int num = 2; num <= target; num++) {
                int counter = 0;

                for (int d = 2; d < num; d++) {
                    if (num % d == 0) {
                        counter++;
                    }
                }

                if (counter == 0) {
                    primesList.Add(num);
                }
            }

            foreach (int num in primesList) {
                Console.Write($"> {num} ");
            }
        }
    }
}
