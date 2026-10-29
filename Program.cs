using LAB06;
using System;

namespace LAB06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] data1 = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            double[,] data2 = {
                { 9, 8, 7 },
                { 6, 5, 4 },
                { 3, 2, 1 }
            };

            Matrix m1 = new Matrix(3, data1);
            Matrix m2 = new Matrix(3, data2);

            Console.WriteLine("Матрица 1:");
            Console.WriteLine(m1);

            Console.WriteLine("Матрица 2:");
            Console.WriteLine(m2);

            Matrix sum = m1 + m2;
            Console.WriteLine("Сумма (m1 + m2):");
            Console.WriteLine(sum);

            Matrix diff = m1 - m2;
            Console.WriteLine("Разность (m1 - m2):");
            Console.WriteLine(diff);

            Matrix mult = m1 * m2;
            Console.WriteLine("Произведение (m1 * m2):");
            Console.WriteLine(mult);

            Matrix div = m1 / 2;
            Console.WriteLine("Деление (m1 / 2):");
            Console.WriteLine(div);

            try
            {
                Matrix error = m1 / 0;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
