using System;
using System.Text;

namespace Functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxHealth = 100;
            int playerHealth;
            char healthSymbol = '#';

            int maxMana = 100;
            int playerMana;
            char manaSymbol = '@';

            int lengthBar = 10;

            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Введите здоровье игрока: ");
            playerHealth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ману игрока: ");
            playerMana = Convert.ToInt32(Console.ReadLine());
            int filledPercent = CalculateFillBarPercent(maxHealth, playerHealth, lengthBar);

            DrawBar(filledPercent, lengthBar, healthSymbol);
            filledPercent = CalculateFillBarPercent(maxMana, playerMana, lengthBar);
            DrawBar(filledPercent, lengthBar, manaSymbol);
        }

        private static int CalculateFillBarPercent(int maxValue, int currentValue, int lengthBar)
        {
            int hundredPercent = 100;
            float procent = Convert.ToSingle(currentValue) / maxValue * hundredPercent;
            int filledPercent = Convert.ToInt32(procent * lengthBar / hundredPercent);
            return filledPercent;
        }

        private static void DrawBar(int fillBarValue, int lengthBar, char barSymbol)
        {
            char emptySymbol = '_';
            string filledBarPart = GetBarPart(barSymbol, fillBarValue);
            string emptyBarPart = GetBarPart(emptySymbol, lengthBar - filledBarPart.Length);
            
            Console.WriteLine('[' + filledBarPart + emptyBarPart + ']');
        }

        private static string GetBarPart(char symbol, int length)
        {
            string filledSymbols = "";

            for (int i = 0; i < length; i++)
            {
                filledSymbols += symbol;
            }

            return filledSymbols;
        }
    }
}
