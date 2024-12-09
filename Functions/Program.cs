using System;
using System.Text;

namespace Functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];
            int maxRandomValue = 9;
            int minRandomValue = 0;

            Console.OutputEncoding = Encoding.Unicode;

            GetRandomArray(numbers, maxRandomValue, minRandomValue);

            Console.WriteLine("Изначальный массив:");
            WriteArray(numbers);

            Shuffle(numbers);

            Console.WriteLine("Получили:");
            WriteArray(numbers);
        }

        private static void Shuffle<T>(T[] array)
        {
            T buffer;

            for (int i = 0; i < array.Length; i++)
            {
                int randomIndex = GetRandomIndex(array.Length);
                buffer = array[i];
                array[i] = array[randomIndex];
                array[randomIndex] = buffer;
            }
        }

        private static void WriteArray<T>(T[] array)
        {
            foreach (T element in array)
            {
                Console.Write(element);
                Console.Write(' ');
            }

            Console.WriteLine();
        }

        private static int GetRandomIndex(int length)
        {
            Random random = new Random();

            return random.Next(length);
        }

        private static void GetRandomArray(int[] array, int maxValue, int minValue)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(minValue, maxValue + 1);
        }
    }
}