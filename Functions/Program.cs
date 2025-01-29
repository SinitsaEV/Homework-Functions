using System;

namespace Functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char playerSymbol = '@';
            char borderSymbol = '#';
            char[,] map =
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' },
                {'#',' ',' ',' ',' ','#',' ',' ',' ','#',' ',' ',' ',' ','#',' ',' ',' ','#' },                
                {'#',' ',' ',' ',' ','#',' ','*',' ','#',' ',' ',' ',' ','#',' ','*',' ','#' },                
                {'#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ','#' },                
                {'#',' ','#','#','#','#',' ',' ',' ',' ',' ','#','#','#','#',' ',' ',' ','#' },                
                {'#',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ','*',' ','#' },                
                {'#',' ','*',' ',' ',' ',' ','#','#',' ',' ','*',' ',' ',' ',' ','#','#','#' },                
                {'#',' ',' ',' ','*',' ','*','#',' ','#',' ',' ',' ','*',' ','*','#',' ','#' },                
                {'#',' ',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ',' ',' ',' ','#',' ','#' },                
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' },
            };

            int playerPositionX = 1;
            int playerPositionY = 1;

            while(true)
            {                
                Console.CursorVisible = false;

                DrawMap(map);
                DrawPlayer(playerPositionX, playerPositionY, playerSymbol);

                ConsoleKeyInfo pressedKey = Console.ReadKey();
                HandleInput(pressedKey, ref playerPositionX, ref playerPositionY, map, borderSymbol);
            }            
        }

        private static void HandleInput(ConsoleKeyInfo pressedKey, ref int playerPositionX, ref int playerPositionY, char[,] map,char borderSymbor)
        {
            int[] direction = GetDirection(pressedKey);

            int nextPlayerX = playerPositionX + direction[0];
            int nextPlayerY = playerPositionY + direction[1];

            if (map[nextPlayerY, nextPlayerX] != borderSymbor)
            {
                playerPositionX = nextPlayerX;
                playerPositionY = nextPlayerY;
            }
        }

        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            int[] direction = { 0, 0 };

            if (pressedKey.Key == ConsoleKey.UpArrow)
                direction[1] = -1;
            else if(pressedKey.Key == ConsoleKey.DownArrow)
                direction[1] = 1;
            else if(pressedKey.Key == ConsoleKey.LeftArrow)
                direction[0] = -1;
            else if(pressedKey.Key == ConsoleKey.RightArrow)
                direction[0] = 1;
            
            return direction;
        }

        private static void DrawMap(char[,] map)
        {
            Console.Clear();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void DrawPlayer(int playerPositionX,int playerPositionY,char playerSymbol)
        {
            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.Write(playerSymbol);
        }
    }
}