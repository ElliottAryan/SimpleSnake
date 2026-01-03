using System;
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
        static void Main(string[] args)
        {
            MapInit(20);
            Console.Write(MapToString(map));
            while (true) {
                var key = Console.ReadKey();
                switch (key.Key) {
                    case ConsoleKey.W: MovePlayer(0,-1); Console.Clear(); Console.Write(MapToString(map)); break;

                    case ConsoleKey.A: MovePlayer(-1,0); Console.Clear(); Console.Write(MapToString(map)); break;

                    case ConsoleKey.D: MovePlayer(1,0); Console.Clear(); Console.Write(MapToString(map)); break;

                    case ConsoleKey.S: MovePlayer(0,1); Console.Clear(); Console.Write(MapToString(map)); break;
                }
                
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
            if (playerX + x < map.GetLength(1) - 1 && playerX + x >= 1) {
                if (playerY + y < map.GetLength(0) - 1 && playerY + y >= 1)
                {
                    map[playerX, playerY] = " ";
                    map[playerX + x, playerY + y] = "X";
                    playerX = playerX + x;
                    playerY = playerY + y;
                }
            }
        }
    }
}
