using Laba_2;
using System;

namespace Laba_2
{
    public partial class Matrix
    {
        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A.Width != B.Width || A.Height != B.Height)
            {
                throw new ArgumentException("Matrices must be of the same size for addition.");
            }
                double[,] new_matrix = new double[A.Width,A.Height];
                for(int i = 0; i < A.Width; i++)
                {
                    for(int j = 0; j < A.Height; j++)
                    {
                        new_matrix[i, j] = A[i, j] + B[i, j];
                    }
                }
                return new Matrix(new_matrix);
            
        }
        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.Width != B.Height)
            {
                throw new ArgumentException("Matrices cannot be multiplied");
                
            }

            Matrix result = new Matrix(A.Height, B.Width);

            for (int i = 0; i < A.Height; i++)
            {
                for (int j = 0; j < B.Width; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < A.Width; k++) 
                    {
                        result[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            return result;
        }
        private double[,] Get_Transported_Array()
        {
            int width = this.Width;
            int height =this.Height;
            double[,] doubles = new double[height, width];
            for(int j = 0; j < height; j++)
            {
                for(int i = 0; i < width; i++)
                {
                    doubles[i, j] = this[j, i];
                }
            }
            return doubles;
        }
        public Matrix Get_Transported_Copy()
        {
            double[,] new_matrix=this.Get_Transported_Array();
            return new Matrix(new_matrix); 
        }
        private void Transpone_Me()
        {
            this.matrix = Get_Transported_Array();
        }
        public double Determinant()
        {
            if (!this.is_determinant_valid)
            {
                if (this.Width !=this.Height)
                    throw new InvalidOperationException("Determinant can only be calculated for square matrices.");

                double[,] matrix_copy = new double[Height, Width];
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        matrix_copy[i, j] = matrix[i, j];
                    }
                }
                this.cached_determinant = CalculateDeterminantRecursive(matrix_copy);
                this.is_determinant_valid = true;
            }
            return cached_determinant.Value;
        }
        private double CalculateDeterminantRecursive(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (n == 1) return matrix[0, 0];
            if (n == 2) return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

            double determinant = 0;
            for (int col = 0; col < n; col++)
            {
                double[,] subMatrix = CreateSubMatrix(matrix, 0, col);
                determinant += (col % 2 == 0 ? 1 : -1) * matrix[0, col] * CalculateDeterminantRecursive(subMatrix);
            }
            return determinant;
        }

        private double[,] CreateSubMatrix(double[,] matrix, int excludingRow, int excludingCol)
        {
            int n = matrix.GetLength(0);
            double[,] result = new double[n - 1, n - 1];
            int r = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == excludingRow) continue;
                int c = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == excludingCol) continue;
                    result[r, c] = matrix[i, j];
                    c++;
                }
                r++;
            }
            return result;
        }
    }
}
