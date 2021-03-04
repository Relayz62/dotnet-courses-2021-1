using System;

namespace Task1
{
    //Написать программу, которая определяет среднюю длину слова во введенной текстовой строке.
    //Учесть, что символы пунктуации на длину слов влиять не должны.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Написать программу, которая определяет среднюю длину слова во введенной текстовой строке." +
                "Учесть, что символы пунктуации на длину слов влиять не должны.");
            int wordLenght =0;
            double avgWordLenght;
            Console.WriteLine("Введите текст:");
            string text;
            text = Console.ReadLine();
            var stringArray = text.Split(new char[] { ' ', ',', '.', ':', ';', '-', '?', '!'}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < stringArray.Length; i++)
            {
                Console.WriteLine("Слово№ {0}: {1}", i,stringArray[i]);
                wordLenght += stringArray[i].Length;               
            }

            Console.WriteLine("Длина всех слов: {0}",wordLenght);
            Console.WriteLine("Количество слов в массиве: {0}", stringArray.Length);
            avgWordLenght = wordLenght / stringArray.Length;
            Console.WriteLine("Средняя длина слова: {0}",avgWordLenght);
            Console.ReadKey();

            
        }
    }
}
