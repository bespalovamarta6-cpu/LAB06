using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB06
{
    public class Matrix
    {
        private int size;
        private double[,] data;

        public int Size
        {
            get { return size; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Размерность матрицы должна быть больше 0.");
                size = value;
            }
        }

        public double[,] Data
        {
            get { return data; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Массив данных не может быть null.");
                data = value;
            }
        }

        public Matrix(int size, double[,] data)
        {
            if (size <= 0)
                throw new ArgumentException("Размерность матрицы должна быть больше 0.");
            if (data == null)
                throw new ArgumentException("Массив не может быть null.");
            if (data.GetLength(0) != size || data.GetLength(1) != size)
                throw new ArgumentException("Размер массива должен соответствовать размеру матрицы (size x size).");

            this.size = size;
            this.data = data;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < size; i++)
            {
                result += "|";
                for (int j = 0; j < size; j++)
                {
                    result += $"{data[i, j],3}"; 
                }
                result += "|\n";
            }
            return result;
        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A.Size != B.Size)
                throw new ArgumentException("Размерности матриц должны совпадать для сложения.");

            double[,] newData = new double[A.Size, A.Size];
            for (int i = 0; i < A.Size; i++)
                for (int j = 0; j < A.Size; j++)
                    newData[i, j] = A.Data[i, j] + B.Data[i, j];

            return new Matrix(A.Size, newData);
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            if (A.Size != B.Size)
                throw new ArgumentException("Размерности матриц должны совпадать для вычитания.");

            double[,] newData = new double[A.Size, A.Size];
            for (int i = 0; i < A.Size; i++)
                for (int j = 0; j < A.Size; j++)
                    newData[i, j] = A.Data[i, j] - B.Data[i, j];

            return new Matrix(A.Size, newData);
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.Size != B.Size)
                throw new ArgumentException("Размерности матриц должны совпадать для умножения.");

            double[,] newData = new double[A.Size, A.Size];
            for (int i = 0; i < A.Size; i++)
                for (int j = 0; j < A.Size; j++)
                    newData[i, j] = A.Data[i, j] * B.Data[i, j];

            return new Matrix(A.Size, newData);
        }

        public static Matrix operator /(Matrix A, double k)
        {
            if (k == 0)
                throw new DivideByZeroException("Деление на ноль невозможно.");

            double[,] newData = new double[A.Size, A.Size];
            for (int i = 0; i < A.Size; i++)
                for (int j = 0; j < A.Size; j++)
                    newData[i, j] = A.Data[i, j] / k;

            return new Matrix(A.Size, newData);
        }
    }
}
