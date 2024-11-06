using System;
using Laba_3;
using System.IO;

namespace Laba_3
{
    class Task1
    {
        public static void Main()
        {
            string current_directory = @"C:\\Users\\ADMIN\\Documents\\GitHub\\OPP\\Laba_3";

            try
            {
                string files_tasks = Path.Combine(current_directory, "Files");
                Directory.CreateDirectory(files_tasks);

                Random random = new Random();
                for (int i = 10; i <= 29; i++)
                {
                    string file_path = Path.Combine(files_tasks, $"{i}.txt");
                    using (var file = new FileStream(file_path, FileMode.Create))
                    {
                        using (var text = new StreamWriter(file))
                        {
                            text.WriteLine(random.Next(int.MinValue,int.MaxValue));
                            text.WriteLine(random.Next(-10, 10));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wrong about process: " + ex.ToString());
            }


        }
    }
}
