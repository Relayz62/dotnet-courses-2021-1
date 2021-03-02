using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxValueMass;
            int minValueMass;
            int[] mass = GenerateArray();
            SortAndGetMinAndMaxValues(mass, out minValueMass, out maxValueMass);
            PrintArray(mass);
            Console.WriteLine("Минимальный элемент:{0} Максимальный элемент:{1}", minValueMass, maxValueMass);
            Console.ReadKey();
        }
        #region GenerateArray
        private static int[] GenerateArray()
        {
            Random rnd = new Random();
            int[] mass = new int[20];

            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = rnd.Next(-10, 10);
            }

            return mass;
        }
        #endregion

        #region SortAndGetMinAndMaxValues
        private static int[] SortAndGetMinAndMaxValues(int[] mass, out int minMassValue, out int maxMassValue)
        {
            minMassValue = -1;
            maxMassValue = -1;

            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] > maxMassValue) maxMassValue = mass[i];
                if (mass[i] < minMassValue) minMassValue = mass[i];
            }

            int temp;
            for (int i = 0; i < mass.Length - 1; i++)
            {
                for (int j = i + 1; j < mass.Length; j++)
                {
                    if (mass[i] > mass[j])
                    {
                        temp = mass[i];
                        mass[i] = mass[j];
                        mass[j] = temp;
                    }
                }
            }
            return mass;
        }
        #endregion

        #region PrintArray
        private static void PrintArray(int[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                Console.WriteLine(mass[i]);
            }

        }
        #endregion
    }
}
