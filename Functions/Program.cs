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

            DrawBar(maxHealth, playerHealth, lengthBar, healthSymbol);
            DrawBar(maxMana, playerMana, lengthBar, manaSymbol);
        }

        static private void DrawBar(int maxValue, int currentValue, int lengthBar, char barSymbol)
        {
            int hundredPercent = 100;
            float procent = Convert.ToSingle(currentValue) / maxValue * hundredPercent;
            int barValue = Convert.ToInt32(procent * lengthBar / hundredPercent);
            string bar = "";
            char emptySymbol = '_';
            
            for(int i = 0; i < lengthBar; i++)
            {
                if(barValue > 0)
                {
                    barValue--;
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
