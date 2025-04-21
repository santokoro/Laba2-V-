//using System;

//namespace LinearAlgebraMethods
//{
//    public static class GaussianElimination
//    {
//        // Метод Гаусса без выбора главного элемента
//        public static float[] SolveWithoutPivoting(float[,] matrix, float[] vector)
//        {
//            int n = vector.Length;
            
//            // Прямой ход
//            for (int k = 0; k < n - 1; k++)
//            {
//                for (int i = k + 1; i < n; i++)
//                {
//                    float factor = matrix[i, k] / matrix[k, k];
//                    for (int j = k; j < n; j++)
//                    {
//                        matrix[i, j] -= factor * matrix[k, j];
//                    }
//                    vector[i] -= factor * vector[k];
//                }
//            }
            
//            // Обратный ход
//            float[] solution = new float[n];
//            for (int i = n - 1; i >= 0; i--)
//            {
//                float sum = 0;
//                for (int j = i + 1; j < n; j++)
//                {
//                    sum += matrix[i, j] * solution[j];
//                }
//                solution[i] = (vector[i] - sum) / matrix[i, i];
//            }
            
//            return solution;
//        }
        
//        // Метод Гаусса с выбором главного элемента
//        public static float[] SolveWithPartialPivoting(float[,] matrix, float[] vector)
//        {
//            int n = vector.Length;
            
//            // Прямой ход с выбором главного элемента
//            for (int k = 0; k < n - 1; k++)
//            {
//                // Поиск максимального элемента в столбце
//                int maxRow = k;
//                float maxVal = Math.Abs(matrix[k, k]);
//                for (int i = k + 1; i < n; i++)
//                {
//                    if (Math.Abs(matrix[i, k]) > maxVal)
//                    {
//                        maxVal = Math.Abs(matrix[i, k]);
//                        maxRow = i;
//                    }
//                }
                
//                // Перестановка строк
//                if (maxRow != k)
//                {
//                    for (int j = k; j < n; j++)
//                    {
//                        float temp = matrix[k, j];
//                        matrix[k, j] = matrix[maxRow, j];
//                        matrix[maxRow, j] = temp;
//                    }
                    
//                    float tempVector = vector[k];
//                    vector[k] = vector[maxRow];
//                    vector[maxRow] = tempVector;
//                }
                
//                // Исключение
//                for (int i = k + 1; i < n; i++)
//                {
//                    float factor = matrix[i, k] / matrix[k, k];
//                    for (int j = k; j < n; j++)
//                    {
//                        matrix[i, j] -= factor * matrix[k, j];
//                    }
//                    vector[i] -= factor * vector[k];
//                }
//            }
            
//            // Обратный ход
//            float[] solution = new float[n];
//            for (int i = n - 1; i >= 0; i--)
//            {
//                float sum = 0;
//                for (int j = i + 1; j < n; j++)
//                {
//                    sum += matrix[i, j] * solution[j];
//                }
//                solution[i] = (vector[i] - sum) / matrix[i, i];
//            }
            
//            return solution;
//        }
//    }
    
//    class Program
//    {
//        static void Main()
//        {
//            // СЛАУ 1 из задания
//            float[,] matrix1 = {
//                {15, 20, 30, 40},
//                {1, 1.333333f, 1, 1},
//                {4, 3, 2, 1},
//                {-1, 1, -1, 1}
//            };
            
//            float[] vector1 = {105, 4.333333f, 10, 0};
            
//            // Решение без выбора главного элемента
//            float[] solution1 = GaussianElimination.SolveWithoutPivoting(
//                (float[,])matrix1.Clone(), (float[])vector1.Clone());
//            Console.WriteLine("Решение без выбора главного элемента:");
//            PrintSolution(solution1);
            
//            // Решение с выбором главного элемента
//            float[] solution2 = GaussianElimination.SolveWithPartialPivoting(
//                (float[,])matrix1.Clone(), (float[])vector1.Clone());
//            Console.WriteLine("\nРешение с выбором главного элемента:");
//            PrintSolution(solution2);
//        }
        
//        static void PrintSolution(float[] solution)
//        {
//            for (int i = 0; i < solution.Length; i++)
//            {
//                Console.WriteLine($"x[{i}] = {solution[i]}");
//            }
//        }
//    }
//}