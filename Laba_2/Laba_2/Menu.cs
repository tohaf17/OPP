using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Text;
using System.Threading.Tasks;
using Laba_2;
using Lab4;


namespace Laba_2
{
    class Menu
    {
        public static void Operations(Matrix A, Matrix B)
        {
                WriteLine("The sum of matrices:");
                WriteLine(A + B + "\n");
            
            
                WriteLine("The multiplying A*B: ");
                WriteLine(A * B);
            
            
                WriteLine("The multiplying B*A");
                WriteLine(B * A + "\n");
            
            
                WriteLine("The transporting:");
                A = A.Get_Transported_Copy();
                WriteLine(A);

            WriteLine(A.Determinant());
            
        }
        public static void Blok_1()
        {
            WriteLine("Inputing the first matrix. Number of rows: ");
            //int n = int.Parse(ReadLine());

            //WriteLine("Input the rows of the matrix");
            //string[] data = new string[n];
            //for (int i = 0; i < n; i++)
            //{
            //    data[i] = ReadLine();
            //}
            List<Matrix> matrices = Matrix.Matrix_From_File("C:\\Users\\ADMIN\\Documents\\GitHub\\OPP\\Laba_2\\Laba_2\\input.txt");
            Matrix A= matrices[0];
            WriteLine(A);

            WriteLine("Inputing the second matrix. Number of rows:");
            //int two_n = int.Parse(ReadLine());
            //WriteLine("Input the rows of the matrix");
            //string[] two_data = new string[two_n];
            //for (int i = 0; i < n; i++)
            //{
            //    two_data[i] = ReadLine();
            //}
            Matrix B = matrices[2];
            WriteLine(B);
            Matrix matric_copy= new Matrix(A);
            matric_copy[0, 0] = -100;
            WriteLine(matric_copy);
            WriteLine(A);
            Operations(A, B);
        }

        public static void Blok_2()
        {
            try
            {
                WriteLine("Введіть чисельник та знаменник першого дробу");
                int a = int.Parse(ReadLine());
                int b = int.Parse(ReadLine());
                MyFrac one = new MyFrac(a, b);

                WriteLine("\nВведіть чисельник та знаменник другого дробу");
                int c = int.Parse(ReadLine());
                int d = int.Parse(ReadLine());
                MyFrac two = new MyFrac(c, d);

                WriteLine("\nДійсні значення дробів: ");
                WriteLine("1 дріб: " + one.DoubleValue());
                WriteLine("2 дріб: " + two.DoubleValue());

                WriteLine("\nТепер виведемо мішані числа якщо вони є");
                WriteLine(one.ToStringWithIntPart());
                WriteLine(two.ToStringWithIntPart());


                WriteLine("\nОперації");
                WriteLine(one+two);
                WriteLine(one-two);
                WriteLine(one * two);
                WriteLine(one / two);

                WriteLine("\nВведіть тепер значення 'n' ");
                int length = int.Parse(ReadLine());
                WriteLine("Перше значення: " + MyFrac.CalcExpr1(length));
                WriteLine("Друге значення: " + MyFrac.CalcExpr2(length));
            }
            catch (Exception ex)
            {
                WriteLine("An error occurred: " + ex.Message);
            }
        }
        public static void Main()
        {
            OutputEncoding = Encoding.UTF8;
            Write("Blok: ");
            int blok = int.Parse(ReadLine());
            switch (blok)
            {
                case 1:
                    Blok_1();
                    break;
                case 2:
                    Blok_2();
                    break;
            }
            
        }
    }
}
