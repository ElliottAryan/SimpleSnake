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
            String test = MapToString(map);
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
        }

        static string MapToString(string[,] map) {
            
        }
    }
}
