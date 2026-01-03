using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxGame
{
    internal class Program
    {

        static string[,] map;
        static int playerX;
        static int playerY;
        static int xDirection;
        static int yDirection;
        static bool gameOver;
        static List<int[]> parts;
        static async Task Main(string[] args)
        {
            Console.CursorVisible = false;
            MapInit(20);
            Console.Write(MapToString(map));
            while (!gameOver) {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.W: xDirection = 0; yDirection = -1; break;

                        case ConsoleKey.A: xDirection = -1; yDirection = 0; break;

                        case ConsoleKey.D: xDirection = 1; yDirection = 0; break;

                        case ConsoleKey.S: xDirection = 0; yDirection = 1; break;
                    }
                }
                MovePlayer(xDirection, yDirection);
                Console.SetCursorPosition(0, 0);
                Console.Write(MapToString(map));
                await Task.Delay(100);    
            }
            
        }

        static void MapInit(int mapSize) {
            map = new string[mapSize, mapSize];
            for (int y = 0; y < map.GetLength(0); y++) {
                for (int x = 0; x < map.GetLength(1); x++) {
                    map[x, y] = " ";
                    if (y == 0 || y == map.GetLength(0) - 1)
                    {
                        map[x, y] = "O";
                    }
                    if (x == 0 || x == map.GetLength(1) - 1) {
                        map[x, y] = "O";
                    }
                }
            }
            Random random = new Random();
            playerX = random.Next(1, map.GetLength(1) - 2);
            playerY = random.Next(1, map.GetLength(0) - 2);
            map[playerX, playerY] = "X";
        }

        static string MapToString(string[,] map) {
            StringBuilder finalString = new StringBuilder();
            int count = 0;
            for (int y = 0; y < map.GetLength(0); y++) {
                for (int x = 0; x < map.GetLength(1); x++) {
                    finalString.Append(map[x, y]);
                }
                finalString.AppendLine();
            }
            return finalString.ToString();
        }

        static void MovePlayer(int x,int y) {
            xDirection = x;
            yDirection = y;
            if (playerX + xDirection > map.GetLength(0) - 1 || playerX + xDirection < 1) {
                gameOver = true;
                return;
            }
            if (playerY + yDirection > map.GetLength(0) - 1 || playerY + yDirection < 1)
            {
                gameOver = true;
                return;
            }
            map[playerX, playerY] = " ";
            map[playerX + xDirection, playerY + yDirection] = "X";
            foreach (int[] part in parts) { 
                
            }
            playerX = playerX + xDirection;
            playerY = playerY + yDirection;
        }
    }
}
