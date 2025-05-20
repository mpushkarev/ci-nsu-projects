/******************************************************************************\
*                                                                              *
*  Author:     Mikhail Pushkarev (CI NSU)                                      *
*  Created:    Approx. February – June 2024                                    *
*                                                                              *
*  Description:                                                                *
*    Manual implementation of insertion sort algorithm. Written                *
*    without relying on built-in sorting functions, to practice                *
*    algorithm development and understanding the sorting process.              *
*    As this was developed at an early stage of learning C#,                   *
*    some parts may be suboptimal or could benefit from further                *
*    refinement.                                                               *
*                                                                              *
\******************************************************************************/

namespace InsertionSort {
    internal class Program {

        private const int ARR_MIN = 1;
        private const int ARR_MAX = 99;
        private const int ARR_LENGTH = 15;

        static void Main() {

            RandomTools randomTools = new RandomTools();

            int[] arr = randomTools.GetArrWithRandNums(ARR_MIN, ARR_MAX, ARR_LENGTH);
            int[] sortedArr = InsertionSort.Sort(arr);

            Console.WriteLine("* Сортировка случайного списка вставками");
            Console.WriteLine($"- Неотсортированный список: [{String.Join(", ", arr)}]");
            Console.WriteLine($"- Отсортированный список:   [{String.Join(", ", sortedArr)}]");
        }
    }

    class InsertionSort {
        public static int[] Sort(int[] originalArr) {

            int[] arr = originalArr.ToArray();

            for (int idInList = 1; idInList < arr.Length; idInList++) {

                int inFocus = arr[idInList];
                int prevId = idInList - 1;

                while (prevId >= 0 && arr[prevId] > inFocus) {
                    arr[prevId + 1] = arr[prevId];
                    prevId--;
                }

                arr[prevId + 1] = inFocus;
            }
            return arr;
        }
    }

    class RandomTools {

        private Random rand = new Random();

        public int[] GetArrWithRandNums(int min, int max, int length) {

            int[] arrOfNums = new int[length];

            for (int i = 0; i < arrOfNums.Length; i++) {
                arrOfNums[i] = rand.Next(min, max);
            }

            return arrOfNums;
        }
    }
}
