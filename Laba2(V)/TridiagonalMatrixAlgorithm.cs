using System;

namespace LinearAlgebraMethods
{
    public static class TridiagonalMatrixAlgorithm
    {
        // Метод прогонки (Томаса) для трехдиагональных матриц
        public static float[] Solve(float[] a, float[] b, float[] c, float[] d)
        {
            int n = d.Length;

            // Проверка входных данных
            if (a.Length != n - 1 || b.Length != n || c.Length != n - 1)
                throw new ArgumentException("Неверные размеры входных массивов");

            float[] cPrime = new float[n - 1];
            float[] dPrime = new float[n];
            float[] x = new float[n];

            // Прямой ход
            cPrime[0] = c[0] / b[0];
            dPrime[0] = d[0] / b[0];

            for (int i = 1; i < n - 1; i++)
            {
                float denominator = b[i] - a[i - 1] * cPrime[i - 1];
                cPrime[i] = c[i] / denominator;
                dPrime[i] = (d[i] - a[i - 1] * dPrime[i - 1]) / denominator;
            }

            // Последний шаг прямого хода
            dPrime[n - 1] = (d[n - 1] - a[n - 2] * dPrime[n - 2]) /
                           (b[n - 1] - a[n - 2] * cPrime[n - 2]);

            // Обратный ход
            x[n - 1] = dPrime[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                x[i] = dPrime[i] - cPrime[i] * x[i + 1];
            }

            return x;
        }
    }

    class Program
    {
        static void Main()
        {
            // Пример трехдиагональной системы
            float[] a = { 1, 1, 1 }; // нижняя диагональ (n-1 элементов)
            float[] b = { 4, 4, 4, 4 }; // главная диагональ (n элементов)
            float[] c = { 1, 1, 1 }; // верхняя диагональ (n-1 элементов)
            float[] d = { 5, 6, 6, 5 }; // вектор правой части

            float[] solution = TridiagonalMatrixAlgorithm.Solve(a, b, c, d);

            Console.WriteLine("Решение трехдиагональной системы:");
            for (int i = 0; i < solution.Length; i++)
            {
                Console.WriteLine($"x[{i}] = {solution[i]:F6}");
            }
        }
    }
}