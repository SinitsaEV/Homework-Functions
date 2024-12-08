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

            DrawBar(CalculateFillBarValue(maxHealth, playerHealth, lengthBar), lengthBar, healthSymbol);
            DrawBar(CalculateFillBarValue(maxMana, playerMana, lengthBar), lengthBar, manaSymbol);
        }

        private static int CalculateFillBarValue(int maxValue, int currentValue, int lengthBar)
        {
            int hundredPercent = 100;
            float procent = Convert.ToSingle(currentValue) / maxValue * hundredPercent;
            int barValue = Convert.ToInt32(procent * lengthBar / hundredPercent);
            return barValue;
        }

        private static void DrawBar(int fillBarValue, int lengthBar, char barSymbol)
        {
            string bar = "";
            char emptySymbol = '_';

            for (int i = 0; i < lengthBar; i++)
            {
                if (fillBarValue > 0)
                {
                    fillBarValue--;
                    bar += barSymbol;
                }
                else
                {
                    bar += emptySymbol;
                }
            }

            Console.WriteLine('[' + bar + ']');
        }
    }
}
