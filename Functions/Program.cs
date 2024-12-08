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
            bool isTakeNumber = false;
            int playerNumber = 0;

            while (isTakeNumber == false)
            {
                Console.Write("Введите число: ");
                string playerInput = Console.ReadLine();                
                isTakeNumber = int.TryParse(playerInput, out playerNumber);

                if (isTakeNumber == false)
                    Console.WriteLine("Ошибка ввода.");                
            }

            return playerNumber;
        }
    }
}
