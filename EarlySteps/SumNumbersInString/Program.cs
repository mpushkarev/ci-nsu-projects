/******************************************************************************\
*                                                                              *
*  Author:     Mikhail Pushkarev (CI NSU)                                      *
*  Created:    Approx. September - December 2023                               *
*                                                                              *
*  Description:                                                                *
*    Simple program to calculate the sum of numbers provided in                *
*    a string. Primarily written for practicing loops,                         *
*    numeric logic, and input/output. Utility is minimal; serves               *
*    as an exercise in basic algorithmic thinking.                             *
*    This was one of the very first projects written during the                *
*    initial stages of learning C#. May contain naive logic or                 *
*    areas for improvement.                                                    *
*                                                                              *
\******************************************************************************/

namespace SumNumbersInString {
    internal class Program {
        static void Main() {

            List<string> numbersList = new List<string>();
            bool wasDigit = false;

            string inputString = Console.ReadLine();

            for (int i = 0; i < inputString.Length; i++) {

                if (inputString[i] >= '0' && inputString[i] <= '9') {

                    string inputDigit = Convert.ToString(inputString[i]);

                    if (wasDigit) {
                        string lastNumber = numbersList[numbersList.Count - 1];
                        numbersList[numbersList.Count - 1] = lastNumber + inputDigit;
                    } else {
                        numbersList.Add(inputDigit);
                    }
                    wasDigit = true;
                } else {
                    wasDigit = false;
                }
            }

            int sumOfNumbers = 0;

            foreach (string element in numbersList) {
                int number = int.Parse(element);
                sumOfNumbers += number;
            }

            Console.WriteLine(sumOfNumbers);
        }
    }
}
