using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxGame
{
    internal class Program
    {

        static string[,] map;
        static void Main(string[] args)
        {
            MapInit(20);
            Console.WriteLine(MapToString(map));
            
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
            int playerX = random.Next(1, map.GetLength(1) - 2);
            int playerY = random.Next(1, map.GetLength(0) - 2);
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
    }
}
