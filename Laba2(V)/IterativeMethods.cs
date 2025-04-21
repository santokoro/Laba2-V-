//using System;

//namespace LinearAlgebraMethods
//{
//    public static class IterativeMethods
//    {
//        // Метод Якоби
//        public static float[] Jacobi(float[,] A, float[] b, float epsilon, int maxIterations = 1000)
//        {
//            int n = b.Length;
//            float[] x = new float[n];
//            float[] xNew = new float[n];
//            int iteration = 0;
//            float error;

//            do
//            {
//                for (int i = 0; i < n; i++)
//                {
//                    float sum = 0;
//                    for (int j = 0; j < n; j++)
//                    {
//                        if (j != i) sum += A[i, j] * x[j];
//                    }
//                    xNew[i] = (b[i] - sum) / A[i, i];
//                }

//                // Вычисление погрешности
//                error = 0;
//                for (int i = 0; i < n; i++)
//                {
//                    error += (float)Math.Abs(xNew[i] - x[i]);
//                    x[i] = xNew[i];
//                }

//                iteration++;
//            } while (error > epsilon && iteration < maxIterations);

//            Console.WriteLine($"Метод Якоби завершен за {iteration} итераций с погрешностью {error}");
//            return x;
//        }

//        // Метод Зейделя
//        public static float[] Seidel(float[,] A, float[] b, float epsilon, int maxIterations = 1000)
//        {
//            int n = b.Length;
//            float[] x = new float[n];
//            int iteration = 0;
//            float error;

//            do
//            {
//                error = 0;
//                for (int i = 0; i < n; i++)
//                {
//                    float sum = 0;
//                    for (int j = 0; j < n; j++)
//                    {
//                        if (j != i) sum += A[i, j] * x[j];
//                    }

//                    float newXi = (b[i] - sum) / A[i, i];
//                    error += (float)Math.Abs(newXi - x[i]);
//                    x[i] = newXi;
//                }

//                iteration++;
//            } while (error > epsilon && iteration < maxIterations);

//            Console.WriteLine($"Метод Зейделя завершен за {iteration} итераций с погрешностью {error}");
//            return x;
//        }

//        // Проверка условия сходимости (диагональное преобладание)
//        public static bool CheckDiagonalDominance(float[,] A)
//        {
//            int n = A.GetLength(0);
//            for (int i = 0; i < n; i++)
//            {
//                float sum = 0;
//                for (int j = 0; j < n; j++)
//                {
//                    if (j != i) sum += Math.Abs(A[i, j]);
//                }
//                if (Math.Abs(A[i, i]) <= sum) return false;
//            }
//            return true;
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            // СЛАУ 2 из задания
//            float[,] matrix2 = {
//                {3, 4, 20},
//                {5, 30, 6},
//                {10, 2, 1}
//            };

//            float[] vector2 = { 27, 41, 13 };

//            // Проверка сходимости
//            if (!IterativeMethods.CheckDiagonalDominance(matrix2))
//            {
//                Console.WriteLine("Исходная матрица не имеет диагонального преобладания. Преобразуем...");

//                // Преобразование для обеспечения диагонального преобладания
//                // Переставляем строки для максимальных диагональных элементов
//                for (int i = 0; i < 3; i++)
//                {
//                    // Находим строку с максимальным элементом в столбце i
//                    int maxRow = i;
//                    for (int j = i + 1; j < 3; j++)
//                    {
//                        if (Math.Abs(matrix2[j, i]) > Math.Abs(matrix2[maxRow, i]))
//                            maxRow = j;
//                    }

//                    // Меняем местами строки
//                    if (maxRow != i)
//                    {
//                        for (int j = 0; j < 3; j++)
//                        {
//                            float temp = matrix2[i, j];
//                            matrix2[i, j] = matrix2[maxRow, j];
//                            matrix2[maxRow, j] = temp;
//                        }

//                        float tempVector = vector2[i];
//                        vector2[i] = vector2[maxRow];
//                        vector2[maxRow] = tempVector;
//                    }
//                }

//                Console.WriteLine("Матрица после преобразования:");
//                PrintMatrix(matrix2);
//            }

//            float epsilon = 0.001f; // Точность 10^-3

//            // Решение методом Якоби
//            float[] solutionJacobi = IterativeMethods.Jacobi(
//                (float[,])matrix2.Clone(), (float[])vector2.Clone(), epsilon);
//            Console.WriteLine("\nРешение методом Якоби:");
//            PrintSolution(solutionJacobi);

//            // Решение методом Зейделя
//            float[] solutionSeidel = IterativeMethods.Seidel(
//                (float[,])matrix2.Clone(), (float[])vector2.Clone(), epsilon);
//            Console.WriteLine("\nРешение методом Зейделя:");
//            PrintSolution(solutionSeidel);
//        }

//        static void PrintMatrix(float[,] matrix)
//        {
//            int rows = matrix.GetLength(0);
//            int cols = matrix.GetLength(1);

//            for (int i = 0; i < rows; i++)
//            {
//                for (int j = 0; j < cols; j++)
//                {
//                    Console.Write($"{matrix[i, j],8:F4}");
//                }
//                Console.WriteLine();
//            }
//        }

//        static void PrintSolution(float[] solution)
//        {
//            for (int i = 0; i < solution.Length; i++)
//            {
//                Console.WriteLine($"x[{i}] = {solution[i]:F6}");
//            }
//        }
//    }
//}