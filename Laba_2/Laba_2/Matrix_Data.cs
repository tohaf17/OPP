using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
namespace Laba_2
{
    public partial class Matrix
    {
        private double[,] matrix;
        private double? cached_determinant = null;
        private bool is_determinant_valid=false;

        private static List<Matrix> list_of_matrices;

        public static List<Matrix> Matrix_From_File(string file)
        {
            List<Matrix> list_of_matrices = new List<Matrix>();

            using (StreamReader reader = new StreamReader(file))
            {
                List<string> lines = new List<string>();
                string input;

                while ((input = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        if (lines.Count > 0)
                        {
                            list_of_matrices.Add(new Matrix(lines.ToArray())); 
                            lines.Clear();
                        }
                    }
                    else
                    {
                        lines.Add(input);
                    }
                }

                if (lines.Count > 0)
                {
                    list_of_matrices.Add(new Matrix(lines.ToArray()));
                }
            }
            return list_of_matrices;
        }
    
    public Matrix(Matrix other)
        {
            this.matrix = (double[,])other.matrix.Clone() ;
        }
        public Matrix(double[,] matrix)
        {
            this.matrix = (double[,])matrix.Clone();
        }
        public Matrix(int width,int height)
        {
            matrix=new double[width,height];
        }
        public Matrix(double[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            for (int i = 1; i < rows; i++)
            {
                if (matrix[i].Length != cols)
                {
                    throw new ArgumentException("Difference between rows");
                }
            }

            this.matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.matrix[i, j] = matrix[i][j];
                }
            }
        }
        public Matrix(string[] data)
        {
            int rows = data.Length;
            int cols = data[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            matrix = new double[rows, cols];    
            for (int i = 0; i < rows; i++)
            {
                string[] current = data[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (current.Length != cols)
                {
                    throw new ArgumentException("Difference between rows");
                }
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = double.Parse(current[j]);
                }
            }
        }
        public Matrix(string input)
        {
            string[] lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = lines.Length;

            string[] firstLineNumbers = lines[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int cols = firstLineNumbers.Length;

            matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] numbers = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length != cols)
                {
                    throw new ArgumentException("Difference between rows");
                }

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = double.Parse(numbers[j]);
                }
            }
        }
        public int Height
        {
            get
            {
                return matrix.GetLength(1);
            }
        }
        public int Width
        {
            get
            {
                return matrix.GetLength(0);
            }
        }

        public int Get_Height()
        {
            return matrix.GetLength(0);
        }
        public int Get_Width()
        {
            return matrix.GetLength(1);
        }
        public double this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= matrix.GetLength(0) || j < 0 || j >= matrix.GetLength(1))
                {
                    throw new ArgumentException($"Index out of range: i={i}, j={j}, matrix size=({matrix.GetLength(0)}, {matrix.GetLength(1)})");
                }
                return matrix[i, j];
            }
            set
            {
                if (i < 0 || i >= matrix.GetLength(0) || j < 0 || j >= matrix.GetLength(1))
                {
                    throw new ArgumentException($"Index out of range: i={i}, j={j}, matrix size=({matrix.GetLength(0)}, {matrix.GetLength(1)})");
                }
                matrix[i, j] = value;
                InvalidateDeterminant();
            }
        }

        public double Get_Value(int i,int j)
        {
            if (i < 0 || i >= matrix.GetLength(0) || j < 0 || j >= matrix.GetLength(1))
            {
                throw new ArgumentException("Index out of array");
            }

            return matrix[i, j];
        }
        public void Set_Value(int i,int j,double value)
        {
            if (i < 0 || i >= matrix.GetLength(0) || j < 0 || j >= matrix.GetLength(1))
            {
                throw new ArgumentException("Index out of array");
            }
            matrix[i, j]=value;
            InvalidateDeterminant();
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            int maxLength = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    string numberStr = matrix[i, j].ToString(); 
                    if (numberStr.Length > maxLength)
                    {
                        maxLength = numberStr.Length;
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    
                    result.Append(matrix[i, j].ToString().PadLeft(maxLength + 1)); 
                }
                result.AppendLine();  
            }

            return result.ToString();
        }
        public void InvalidateDeterminant()
        {
            is_determinant_valid = false;
        }
        public static bool Equals(double[,] array, Matrix matrix)
        {
            if (array.GetLength(0) != matrix.Height || array.GetLength(1) != matrix.Width)
            {
                return false;
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] != matrix[i, j])
                    {
                        return false; 
                    }
                }
            }

            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}