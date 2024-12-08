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

        static private int ReadInt()
        {
            bool IsTakeNumber = false;
            int playerNumber = 0;

            while (IsTakeNumber == false)
            {
                Console.Write("Введите число: ");
                string playerInput = Console.ReadLine();                
                IsTakeNumber = int.TryParse(playerInput, out playerNumber);

                if (IsTakeNumber == false)
                    Console.WriteLine("Ошибка ввода.");                
            }

            return playerNumber;
        }
    }
}
