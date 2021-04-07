using System;
using System.Collections.Generic;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessFile("disposable_task_file.txt");
        }


        private static void ProcessFile(string fileDirectory)
        {
            List<string> lines = new List<string>();
            double digit;
            FileStream fl = new FileStream(fileDirectory, FileMode.OpenOrCreate);
            fl.Close();
            using (StreamReader sr = new StreamReader(fileDirectory))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
            }
            using (StreamWriter sw = new StreamWriter(fileDirectory))
            {
                foreach (var item in lines)
                {
                    double.TryParse(item, out digit);
                    sw.WriteLine(Math.Pow(digit, 2));
                }
            }           
        }
    }
}
