using System;
using System.Text;

namespace Functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine("Ваше число: " + ReadInt());
        }

        private static int ReadInt()
        {
            int number = 0;

            Console.Write("Введите число: ");
            string playerInput = Console.ReadLine();

            while (int.TryParse(playerInput, out number) == false)
            {
                
                if (int.TryParse(playerInput, out number) == false)
                    Console.WriteLine("Ошибка ввода.");
                
                Console.Write("Введите число: ");
                playerInput = Console.ReadLine();
            }

            return number;
        }
    }
}
