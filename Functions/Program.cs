using System;
using System.Data;
using System.Text;

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

            bool isGameActive = true;

            ConsoleKey gameOverKey = ConsoleKey.Escape;
            string gameOverMessage = $" Для завершения игры нажмите {gameOverKey} ";
            int gameOverX = 40;
            int gameOverY = 0;

            Console.OutputEncoding = Encoding.UTF8;

            while (isGameActive)
            {                
                Console.CursorVisible = false;

                DrawMap(map);
                WriteMessage(gameOverX, gameOverY, gameOverMessage);
                DrawPlayer(playerPositionX, playerPositionY, playerSymbol);

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if(pressedKey.Key != gameOverKey)
                {
                    int[] direction = GetDirection(pressedKey);
                    MovePlayer(map, ref playerPositionX, ref playerPositionY, direction, borderSymbol);
                }
                else
                {
                    Console.Clear();
                    isGameActive = false;
                }
            }            
        }

        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            int[] direction = { 0, 0 };
            int positiveDirection = 1;
            int negativeDirection = -1;

            ConsoleKey moveUpCommand = ConsoleKey.UpArrow;
            ConsoleKey moveDownCommand = ConsoleKey.DownArrow;
            ConsoleKey moveLeftCommand = ConsoleKey.LeftArrow;
            ConsoleKey moveRightCommand = ConsoleKey.RightArrow;

            if (pressedKey.Key == moveUpCommand)
                direction[1] = negativeDirection;
            else if(pressedKey.Key == moveDownCommand)
                direction[1] = positiveDirection;
            else if(pressedKey.Key == moveLeftCommand)
                direction[0] = negativeDirection;
            else if(pressedKey.Key == moveRightCommand)
                direction[0] = positiveDirection;
            
            return direction;
        }

        private static void WriteMessage(int positionX, int positionY, string message)
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(message);
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

        private static void MovePlayer(char[,] map, ref int playerPositionX, ref int playerPositionY, int[] direction, char borderSymbor)
        {
            int nextPlayerX = playerPositionX + direction[0];
            int nextPlayerY = playerPositionY + direction[1];

            if (map[nextPlayerY, nextPlayerX] != borderSymbor)
            {
                playerPositionX = nextPlayerX;
                playerPositionY = nextPlayerY;
            }
        }
    }
}
