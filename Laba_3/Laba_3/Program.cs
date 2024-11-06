using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Laba_3;

namespace Laba_3
{
    internal class Base_Task
    {
        public static void Main()
        {
            string files_tasks = @"C:\\Users\\ADMIN\\Documents\\GitHub\\OPP\\Laba_3\\Files";

            
            List<string> files_not_exist = new List<string>();
            List<string> files_not_parsing = new List<string>();
            List<string> files_not_int = new List<string>();

            List<int> multiply = new List<int>();
            for (int i = 10; i <= 29; i++)
            {
                string file = Path.Combine(files_tasks, $"{i}.txt");
                try
                {
                    StreamReader sr = new StreamReader(file);
                    int first = int.Parse(sr.ReadLine());
                    int second = int.Parse(sr.ReadLine());

                    int dobutok = checked(first * second);
                    multiply.Add(dobutok);
                }
                catch (FileNotFoundException _)
                {
                    files_not_exist.Add($"{i}.txt");
                }
                catch (FormatException _)
                {
                    files_not_parsing.Add($"{i}.txt");
                }
                catch (OverflowException _)
                {
                    files_not_int.Add($"{i}.txt");
                }

            }
            try
            {
                long result = multiply.Select(x=>(long)x).Sum() / multiply.Count;
                WriteLine($"Average of file multiplies: {result}");
            }
            catch (OverflowException _)
            {
                WriteLine("We does not the average");
            }
            Build_Directories(files_not_exist, files_not_parsing, files_not_int);
            
        }
        public static void Build_Directories(List<string> a, List<string> b, List<string> c)
        {
            foreach (var file in Directory.GetFiles(@"C:\\Users\\ADMIN\\Documents\\GitHub\\OPP\\Laba_3\\no_file.txt"))
            {
                File.Delete(file);
            }

            foreach (var i in a)
            {
                string folderPath = @"C:\\Users\\ADMIN\\Documents\\GitHub\\OPP\\Laba_3\\no_file.txt";
                string destinationPath = Path.Combine(folderPath, i); 

                File.Create(destinationPath);
            }
            foreach (var file in Directory.GetFiles($@"C:\\Users\\ADMIN\\Documents\\GitHub\\OPP\\Laba_3\\bad_data.txt"))
            {
                File.Delete(file);
            }

            foreach (var i in b)
            {
                string destinationPath = $@"C:\\Users\\ADMIN\\Documents\\GitHub\\OPP\\Laba_3\\bad_data.txt\\{i}";
                string sourcePath = $@"C:\Users\ADMIN\Documents\GitHub\OPP\Laba_3\Files\{i}";

                try
                {
                    File.Copy(sourcePath, destinationPath);
                }
                catch (Exception ex)
                {
                    WriteLine(ex.ToString());
                }
            }
            foreach (var file in Directory.GetFiles($@"C:\\Users\\ADMIN\\Documents\\GitHub\\OPP\\Laba_3\\overflow.txt"))
            {
                File.Delete(file);
            }

            foreach (var i in c)
            {
                string destinationPath = $@"C:\\Users\\ADMIN\\Documents\\GitHub\\OPP\\Laba_3\\overflow.txt\\{i}";
                string sourcePath = $@"C:\Users\ADMIN\Documents\GitHub\OPP\Laba_3\Files\{i}";

                try
                {
                    File.Copy(sourcePath, destinationPath);
                }
                catch (Exception ex)
                {
                    WriteLine(ex.ToString());
                }
            }
        }

    }
}
