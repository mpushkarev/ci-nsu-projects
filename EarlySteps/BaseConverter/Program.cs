/******************************************************************************\
*                                                                              *
*  Author:     Mikhail Pushkarev (CI NSU)                                      *
*  Created:    Approx. September - December 2023                               *
*                                                                              *
*  Description:                                                                *
*    Manually implemented converter between numeral                            *
*    systems (base 2 to 16). Written without using built-in                    *
*    language features for base conversion. Created to practice                *
*    algorithm design and string manipulation.                                 *
*    This was one of the very first projects written during the                *
*    initial stages of learning C#. May contain naive logic or                 *
*    areas for improvement.                                                    *
*                                                                              *
\******************************************************************************/

namespace BaseConverter {
    internal class Program {
        static void Main() {

            Console.Write("Ваше число: ");
            string initalNum = Console.ReadLine();
            Console.Write("Его с/сч: ");
            int initalNumBase = int.Parse(Console.ReadLine());
            Console.Write("Перевод в с/сч: ");
            int targetNumBase = int.Parse(Console.ReadLine());

            string result = ConvertBaseToBase(initalNum, initalNumBase, targetNumBase);

            if (result != "error") {
                Console.WriteLine($"Число {initalNum} в {initalNumBase}-ной системе счисления - это {result} в {targetNumBase}-ной системе счисления.");
            } else {
                Console.WriteLine("Что-то пошло не так или не туда :(");
            }
        }

        static string ConvertBaseToBase(string initalNum, int fromBase, int toBase) {

            if (fromBase >= 2 && toBase >= 2) {
                int convertedToDecimalBase = ConvertToDecimal(initalNum, fromBase);
                string convertedToNewBase = ConvertFromDecimal(convertedToDecimalBase, toBase);
                return convertedToNewBase;
            } else {
                return "error";
            }
        }

        static int ConvertToDecimal(string initalNum, int fromBase) {

            int[] inDigits = new int[initalNum.Length];
            initalNum = initalNum.ToUpper();

            for (int symbID = initalNum.Length - 1; symbID >= 0; symbID--) {

                switch (initalNum[symbID]) {
                    case 'A':
                        inDigits[symbID] = 10;
                        break;
                    case 'B':
                        inDigits[symbID] = 11;
                        break;
                    case 'C':
                        inDigits[symbID] = 12;
                        break;
                    case 'D':
                        inDigits[symbID] = 13;
                        break;
                    case 'E':
                        inDigits[symbID] = 14;
                        break;
                    case 'F':
                        inDigits[symbID] = 15;
                        break;
                    default:
                        inDigits[symbID] = int.Parse(initalNum[symbID].ToString());
                        break;
                }
            }

            double result = 0;
            double pow = inDigits.Length - 1;

            foreach (int digit in inDigits) {
                result += digit * Math.Pow(Convert.ToDouble(fromBase), pow);
                pow--;
            }

            return Convert.ToInt32(result);
        }

        static string ConvertFromDecimal(int initalNum, int toBase) {

            List<int> inDigitsReverse = new List<int>();

            int quotient = initalNum;

            while (quotient >= toBase) {
                int remainder = quotient % toBase;
                inDigitsReverse.Add(remainder);
                quotient /= toBase;
            }

            inDigitsReverse.Add(quotient);

            string result = "";

            for (int digID = inDigitsReverse.Count - 1; digID >= 0; digID--) {
                switch (inDigitsReverse[digID]) {
                    case 10:
                        result += "A";
                        break;
                    case 11:
                        result += "B";
                        break;
                    case 12:
                        result += "C";
                        break;
                    case 13:
                        result += "D";
                        break;
                    case 14:
                        result += "E";
                        break;
                    case 15:
                        result += "F";
                        break;
                    default:
                        result += Convert.ToString(inDigitsReverse[digID]);
                        break;
                }
            }

            return result;
        }
    }
}
