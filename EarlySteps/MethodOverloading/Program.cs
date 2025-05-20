/******************************************************************************\
*                                                                              *
*  Author:     Mikhail Pushkarev (CI NSU)                                      *
*  Created:    Approx. February – June 2024                                    *
*                                                                              *
*  Description:                                                                *
*    Demonstrates method overloading in C# using shape area                    *
*    calculations. Includes overloaded methods to compute                      *
*    area of circles, rectangles, etc. with different parameter sets.          *
*    As this was developed at an early stage of learning C#,                   *
*    some parts may be suboptimal or could benefit from further                *
*    refinement.                                                               *
*                                                                              *
\******************************************************************************/

namespace MethodOverloading {
    internal class Program {
        static void Main() {

            Console.WriteLine("* Geometry - расчёт площади фигур");
            Console.WriteLine("- Возможные фигуры:");
            Console.WriteLine("  • 1 | Круг");
            Console.WriteLine("  • 2 | Прямоугольник");
            Console.WriteLine("  • 3 | Треугольник (3 известных стороны)");
            Console.WriteLine("  • 4 | Шар");
            Console.WriteLine("  • 5 | Цилиндр");
            Console.WriteLine("  • 6 | Параллелепипед");
            Console.WriteLine("  • 7 | Призма (треугольная)");
            Console.Write("- Введите id фигуры: ");

            int figureId = int.Parse(Console.ReadLine());
            double area = 0;

            switch (figureId) {
                case 1:
                    Console.Write("~ radius = ");
                    double radius = double.Parse(Console.ReadLine());
                    area = Geometry.SurfaceArea2D(radius);
                    break;
                case 2:
                    Console.Write("~ length = ");
                    double lengthRect = double.Parse(Console.ReadLine());
                    Console.Write("~ width = ");
                    double widthRect = double.Parse(Console.ReadLine());
                    area = Geometry.SurfaceArea2D(lengthRect, widthRect);
                    break;
                case 3:
                    Console.Write("~ a = ");
                    double side1Tri = double.Parse(Console.ReadLine());
                    Console.Write("~ b = ");
                    double side2Tri = double.Parse(Console.ReadLine());
                    Console.Write("~ c = ");
                    double side3Tri = double.Parse(Console.ReadLine());
                    area = Geometry.SurfaceArea2D(side1Tri, side2Tri, side3Tri);
                    break;
                case 4:
                    Console.Write("~ radius = ");
                    double sphereRadius = double.Parse(Console.ReadLine());
                    area = Geometry.SurfaceArea3D(sphereRadius);
                    break;
                case 5:
                    Console.Write("~ radius = ");
                    double cylinderRadius = double.Parse(Console.ReadLine());
                    Console.Write("~ height = ");
                    double cylinderHeight = double.Parse(Console.ReadLine());
                    area = Geometry.SurfaceArea3D(cylinderRadius, cylinderHeight);
                    break;
                case 6:
                    Console.Write("~ length = ");
                    double boxLength = double.Parse(Console.ReadLine());
                    Console.Write("~ width = ");
                    double boxWidth = double.Parse(Console.ReadLine());
                    Console.Write("~ height = ");
                    double boxHeight = double.Parse(Console.ReadLine());
                    area = Geometry.SurfaceArea3D(boxLength, boxWidth, boxHeight);
                    break;
                case 7:
                    Console.Write("~ a = ");
                    double prismSide1 = double.Parse(Console.ReadLine());
                    Console.Write("~ b = ");
                    double prismSide2 = double.Parse(Console.ReadLine());
                    Console.Write("~ c = ");
                    double prismSide3 = double.Parse(Console.ReadLine());
                    Console.Write("~ height = ");
                    double prismHeight = double.Parse(Console.ReadLine());
                    area = Geometry.SurfaceArea3D(prismSide1, prismSide2, prismSide3, prismHeight);
                    break;
                default:
                    Console.WriteLine("Вы ввели несуществующий id!");
                    break;
            }

            if (figureId >= 1 && figureId <= 7) {
                Console.WriteLine($"~ S = {area}");
            } else {
                Console.WriteLine("Что-ж, попробуем ещё раз!");
                Console.WriteLine(new string('-', 40));
                Program.Main();
            }
        }
    }

    class Geometry {

        public static double SurfaceArea2D(double radius) {
            return Math.PI * Math.Pow(radius, 2);
        }

        public static double SurfaceArea2D(double length, double width) {
            return length * width;
        }

        public static double SurfaceArea2D(double a, double b, double c) {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public static double SurfaceArea3D(double radius) {
            return 4 * Math.PI * Math.Pow(radius, 2);
        }

        public static double SurfaceArea3D(double radius, double height) {
            return 2 * Math.PI * Math.Pow(radius, 2) + 2 * Math.PI * radius * height;
        }

        public static double SurfaceArea3D(double length, double width, double height) {
            return 2 * (length * width + width * height + height * length);
        }

        public static double SurfaceArea3D(double a, double b, double c, double height) {

            double p = (a + b + c) / 2;
            double baseArea = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            double lateralArea = 3 * (height * (a + b + c) / 2);

            return baseArea + lateralArea;
        }
    }
}
